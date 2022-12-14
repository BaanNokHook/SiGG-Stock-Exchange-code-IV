using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SiGGTransactionFinancial.Common.BaseClasses;
using SiGGTransactionFinancial.Common.Settings;
using SiGGTransactionFinancial.Server.Extensions;
using SiGGTransactionFinancial.Server.Interfaces;
using SiGGTransactionFinancial.Server.Services;
using SiGGTransactionFinancial.Server.Settings;
using Michaelsoft.Mailer.Interfaces;
using Michaelsoft.Mailer.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Michaelsoft.Mailer.Services;

namespace SiGGTransactionFinancial.Server
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddEncryptionService(Configuration);
            services.AddUserService(Configuration);
            services.AddTokenService(Configuration);

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.Configure<CommonSettings>(Configuration.GetSection("CommonSettings"));

            //_ = services.AddSingleton<IMailer, Mailer.Service.Mailer>();

            services.AddSingleton<IRoleService, RoleService>();

            services.AddControllers();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            var jwtSettings = Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        RoleClaimType = "roles",
                        NameClaimType = "sub"
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SiGG-Transaction Financial", Version = "V1"});

                c.EnableAnnotations();

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "Header for the JWT. Value should be: \"Bearer {token}\".",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env)
        {
            InjectableServicesBaseStaticClass.Services = app.ApplicationServices;

            if (env.IsProduction())
            {
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    const string basePath = "/";

                    if (env.IsDevelopment())
                        app.UseHttpsRedirection();

                    // set base path for nginx
                    c.PreSerializeFilters.Add((swaggerDoc,
                                               httpReq) => swaggerDoc.Servers = new List<OpenApiServer>
                    {
                        new OpenApiServer
                        {
                            Url = $"https://{httpReq.Host.Value}{basePath}"
                        }
                    });

                    // remove base path from docs in swagger ui
                    c.PreSerializeFilters.Add((swaggerDoc,
                                               httpReq) =>
                    {
                        var paths = new OpenApiPaths();
                        foreach (var path in swaggerDoc.Paths)
                        {
                            paths.Add(path.Key.Replace(basePath, "/"), path.Value);
                        }

                        swaggerDoc.Paths = paths;
                    });
                });
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "BodyGuard Server API V1"); });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

    }
}

namespace Mailer.Service
{
    class Mailer
    {
    }
}