using System.ComponentModel.DataAnnotations;
using SiGGTransactionFinancial.Common.Attributes;
using Newtonsoft.Json;

namespace SiGGTransactionFinancial.Common.HttpModels.Authentication
{
    public class ConfirmRegistrationRequest
    {

        [Required]
        [JsonRequired]
        public string Token { get; set; }

    }
}