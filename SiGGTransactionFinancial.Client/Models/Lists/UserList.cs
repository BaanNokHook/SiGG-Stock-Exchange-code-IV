using System.Collections.Generic;
using SiGGTransactionFinancial.Common.Models;

namespace SiGGTransactionFinancial.Client.Models.Lists
{
    public class UserList
    {

        public string UpdatePage { get; set; } = "/Update";

        public string UpdateArea { get; set; } = "User";

        public string UpdateLabel { get; set; } = "link_update";
        
        public string SuccessArea { get; set; } = "Result";

        public string SuccessPage { get; set; } = "/Success";

        public string FailureArea { get; set; } = "Result";

        public string FailurePage { get; set; } = "/Failure";

    }
}