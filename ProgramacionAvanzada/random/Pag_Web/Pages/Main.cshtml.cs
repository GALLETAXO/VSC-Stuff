
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace Pag_Web.Pages
{


    public class Main : PageModel
    {
        //[BindProperty]
        //public Movies NewMovie {get; set;}
        

        
       // private DbContext _context;

        public Main(DbContext context)
        {
            //_context = context;
        }

        
    

        public void OnGet()
        {

    
        }

        public IActionResult OnPost()
        {
            return RedirectToPage();
        }
    }
}