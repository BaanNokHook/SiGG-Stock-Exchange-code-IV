using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using SiGGTransactionFinancial.Common.Models;
using SiGGTransactionFinancial.Common.Settings;
using Microsoft.Extensions.Options;

namespace SiGGTransactionFinancial.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateEnabledUserDataProperty : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value,
                                                    ValidationContext validationContext)
        {
            // init
            var options = validationContext.GetService(typeof(IOptions<CommonSettings>)) as IOptions<CommonSettings>;
            var identitySettings = options?.Value.IdentitySettings;
            var data = value as string;
            var user = validationContext.ObjectInstance as User;

            // checks
            if (identitySettings == null)
                return ValidationResult.Success;
            if (user == null)
                return ValidationResult.Success;
            if (data == null && (validationContext.MemberName != "EmailAddress" || user.Id != null) && identitySettings.EnabledUserDataProperties.Contains(validationContext.MemberName))
                return new ValidationResult($"{validationContext.DisplayName} field is required");
            return ValidationResult.Success;
        }

    }
}