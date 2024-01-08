using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Repaso_RP.Pages.Shared
{
    public class Main : PageModel
    {
        private readonly ILogger<Main> _logger;

        public Main(ILogger<Main> logger)
        {
            _logger = logger;
        }

        public void OnGet(int? resultado)
        {
            int? res = resultado;

        }

        public IActionResult OnPost()
        {
            1st


            return RedirectToPage(resultado);

        }
        
    }
}