using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using SiGGTransactionFinancial.Client.Interfaces;
using SiGGTransactionFinancial.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SiGGTransactionFinancial.TestWebApp.Areas.Site.Pages
{
    public class IndexModel : PageModel
    {

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
        }

    }
}