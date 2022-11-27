using System.ComponentModel.DataAnnotations;
using SiGGTransactionFinancial.Common.Attributes;
using SiGGTransactionFinancial.Common.Interfaces;
using Newtonsoft.Json;

namespace SiGGTransactionFinancial.Common.Models
{
    public class User : IUser
    {

        [ExcludeFromInsert]
        [ExcludeFromUpdate]
        public string Id { get; set; }

        [MinLength(5)]
        [MaxLength(320)]
        [EmailAddress]
        [ExcludeFromInsert]
        [Display(Name = "email_address")]
        [ValidateEnabledUserDataProperty]
        public string EmailAddress { get; set; }

        [MinLength(2)]
        [MaxLength(64)]
        [Display(Name = "user_name")]
        [ValidateEnabledUserDataProperty]
        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(64)]
        [Display(Name = "user_surname")]
        [ValidateEnabledUserDataProperty]
        public string Surname { get; set; }

        [MinLength(5)]
        [MaxLength(64)]
        [Display(Name = "user_nickname")]
        [ValidateEnabledUserDataProperty]
        public string Nickname { get; set; }

        [MinLength(5)]
        [MaxLength(16)]
        [Display(Name = "user_phone_number")]
        [ValidateEnabledUserDataProperty]
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        [ExcludeFromInsert]
        [ExcludeFromUpdate]
        public string FullName => $"{Surname} {Name}";

    }
}