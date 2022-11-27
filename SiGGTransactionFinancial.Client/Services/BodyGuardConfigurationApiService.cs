using System;
using System.Net.Http;
using System.Threading.Tasks;
using SiGGTransactionFinancial.Client.Interfaces;
using SiGGTransactionFinancial.Client.Settings;
using SiGGTransactionFinancial.Common.HttpModels.Authentication;
using SiGGTransactionFinancial.Common.Models;
using SiGGTransactionFinancial.Common.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace SiGGTransactionFinancial.Client.Services
{
    public class BodyGuardConfigurationApiService : BodyGuardBaseApiService
    {

        private readonly CommonSettings _commonSettings;

        public BodyGuardConfigurationApiService(IBodyGuardClientSettings settings,
                                                IHttpClientFactory httpClientFactory,
                                                IHttpContextAccessor httpContextAccessor,
                                                IOptions<CommonSettings> commonSettings) :
            base(settings, httpClientFactory, httpContextAccessor)
        {
            _commonSettings = commonSettings.Value;
        }

        public async Task ConfigureCommonSettings()
        {
            await PostRequest<UserCreateResponse>("ConfigureCommonSettings", _commonSettings);
        }

    }
}