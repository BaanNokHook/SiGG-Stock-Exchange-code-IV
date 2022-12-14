using SiGGTransactionFinancial.Common.HttpModels.Authentication;

namespace SiGGTransactionFinancial.Client.Models.Forms
{
    public class RegistrationForm
    {

        public UserCreateRequest CreateRequest { get; set; }

        public string SuccessArea { get; set; } = "Result";

        public string SuccessPage { get; set; } = "/Success";

        public string FailureArea { get; set; } = "Authentication";

        public string FailurePage { get; set; } = "/Registration";

        public string SubmitLabel { get; set; } = "submit_register";

    }
}