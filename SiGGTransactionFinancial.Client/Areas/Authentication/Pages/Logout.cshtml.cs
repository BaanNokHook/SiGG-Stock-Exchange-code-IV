using System.Threading.Tasks;
using SiGGTransactionFinancial.Client.Interfaces;
using SiGGTransactionFinancial.Client.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SiGGTransactionFinancial.Client.Areas.Authentication.Pages
{
    public class Logout : PageModel
    {

        private readonly IBodyGuardAuthenticationApiService _authenticationApiService;

        public Logout(IBodyGuardAuthenticationApiService authenticationApiService)
        {
            _authenticationApiService = authenticationApiService;
        }

        [BindProperty]
        public AuthenticationForm AuthenticationForm { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var response = await _authenticationApiService.Logout();

            if (response.Success)
            {
                TempData["Message"] = "Logout succeed!";
                return RedirectToPage(AuthenticationForm.LogoutSuccessPage,
                                      new {Area = AuthenticationForm.LogoutSuccessArea});
            }

            TempData["Message"] = "Logout failed.";
            return RedirectToPage(AuthenticationForm.LogoutFailurePage,
                                  new {Area = AuthenticationForm.LogoutFailureArea});
        }

    }
}