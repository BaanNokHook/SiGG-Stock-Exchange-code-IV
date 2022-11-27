using System;
using System.Collections.Generic;
using SiGGTransactionFinancial.Common.Settings;
using SiGGTransactionFinancial.Server.Interfaces;
using Microsoft.Extensions.Options;

namespace SiGGTransactionFinancial.Server.Services
{
    public class RoleService : IRoleService
    {

        public const string Root = "root";

        public const string Admin = "admin";

        public const string Dpo = "dpo";

        public const string User = "user";

        public List<string> Roles { get; set; } = new List<string>();

        public RoleService(IOptions<CommonSettings> commonSettings)
        {
            Roles.Add(Root);
            Roles.Add(Dpo);
            Roles.Add(Admin);
            Roles.Add(User);
            foreach (var customRole in commonSettings.Value.IdentitySettings.CustomRoles)
                Roles.Add(customRole);
        }

        public string this[string role]
        {
            get => Roles.Contains(role) ? role : null;
            set => throw new InvalidOperationException();
        }

    }
}