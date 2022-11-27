using System.Collections.Generic;
using Newtonsoft.Json;

namespace SiGGTransactionFinancial.Server.Settings
{
    [JsonObject("JwtSettings")]
    public class JwtSettings
    {

        [JsonProperty("Secret")]
        public string Secret { get; set; }

        [JsonProperty("Issuer")]
        public string Issuer { get; set; }

        [JsonProperty("Audience")]
        public string Audience { get; set; }

        [JsonProperty("AccessExpiration")]
        public int AccessExpiration { get; set; }

        [JsonProperty("RefreshExpiration")]
        public int RefreshExpiration { get; set; }

    }
}