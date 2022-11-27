using System.Collections.Generic;

namespace SiGGTransactionFinancial.Common.HttpModels.Authentication
{
    public class UsersDataResponse : BaseResponse
    {

        public Dictionary<string, string> UsersData { get; set; }

    }
}