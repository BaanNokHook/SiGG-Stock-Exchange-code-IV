using SiGGTransactionFinancial.Common.Models;

namespace SiGGTransactionFinancial.Common.HttpModels.Authentication
{
    public class UserUpdateRequest
    {

        public string Id { get; set; }

        public User UserData { get; set; }

    }
}