using System.Threading.Tasks;
using SiGGTransactionFinancial.Common.HttpModels.Authentication;
using SiGGTransactionFinancial.Common.Models;

namespace SiGGTransactionFinancial.Client.Interfaces
{
    public interface IBodyGuardAuthenticationApiService
    {

        public Task<UserCreateResponse> Register(string email,
                                                 string password,
                                                 User userData = null);

        public Task<UserLoginResponse> Login(string email,
                                             string password);

        public Task<UserLogoutResponse> Logout();

        public Task<ValidateRecoveryResponse> ValidateRecovery(string emailAddress,
                                                               string token,
                                                               string newPassword,
                                                               string newPasswordConfirm);

        public Task<PasswordRecoveryResponse> PasswordRecovery(string emailAddress,
                                                               int ttlSeconds,
                                                               string validateRecoveryUrl);

        public Task<ConfirmRegistrationResponse> ConfirmRegistration(string token);

        public Task<RegistrationEmailResponse> SendRegistrationEmail(string emailAddress,
                                                                     int ttlSeconds,
                                                                     string confirmRegistrationUrl);

    }
}