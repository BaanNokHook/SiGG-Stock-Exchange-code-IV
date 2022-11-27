using System.Threading.Tasks;
using SiGGTransactionFinancial.Client.Interfaces;
using SiGGTransactionFinancial.Client.Models.Forms;
using SiGGTransactionFinancial.Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SiGGTransactionFinancial.Client.Areas.User.Pages
{
    public class Update : PageModel
    {

        private readonly IBodyGuardUserApiService _userApiService;

        public Update(IBodyGuardUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        [BindProperty]
        public UpdateForm UpdateForm { get; set; }

        public void OnGet(string id)
        {
            UpdateForm = new UpdateForm();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData.Set("FormStatus", new FormStatus(ModelState));
                return RedirectToPage(UpdateForm.FailurePage,
                                      new {Area = UpdateForm.FailureArea, Id = UpdateForm.User.Id});
            }

            var response = await _userApiService.UpdateUser(UpdateForm.User);

            if (response.Success)
            {
                TempData["Message"] = "Update succeed!";
                return RedirectToPage(UpdateForm.SuccessPage,
                                      new {Area = UpdateForm.SuccessArea, Id = UpdateForm.User.Id});
            }

            TempData["Message"] = "Update failed.";
            return RedirectToPage(UpdateForm.FailurePage,
                                  new {Area = UpdateForm.FailureArea, Id = UpdateForm.User.Id});
        }

    }
}