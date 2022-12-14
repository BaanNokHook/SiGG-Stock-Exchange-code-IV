using System.Collections.Generic;
using SiGGTransactionFinancial.Common.Models;

namespace SiGGTransactionFinancial.Client.Models.Forms
{
    public class DeleteForm
    {

        public string Id { get; set; }

        public string SuccessArea { get; set; } = "Result";

        public string SuccessPage { get; set; } = "/Success";

        public string FailureArea { get; set; } = "Result";

        public string FailurePage { get; set; } = "/Failure";

        public string SubmitLabel { get; set; } = "submit_delete";

    }
}