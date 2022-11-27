using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SiGGTransactionFinancial.TestWebApp.Areas.Site.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class FailureModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly ILogger<FailureModel> _logger;

        public FailureModel(ILogger<FailureModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}
