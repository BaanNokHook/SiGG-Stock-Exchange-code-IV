using System.Threading;
using SiGGTransactionFinancial.Client.Utilities;
using SiGGTransactionFinancial.Common.BaseClasses;
using Microsoft.AspNetCore.Builder;

namespace SiGGTransactionFinancial.Client.Extensions
{
    public static class ApplicationBuilderExtension
    {

        public static void AddBodyGuard(this IApplicationBuilder app)
        {
            app.UseRequestLocalization();

            InjectableServicesBaseStaticClass.Services = app.ApplicationServices;
            Thread.Sleep(5000); //Sleep to allow server to come up
            BodyGuardConfigurationUtility.ConfigureCommonSettings();
        }

    }
}