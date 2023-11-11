using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Common.Entities;

namespace Northwind.Pages.Categories
{
    public class AddModel : PageModel
    {
        private  Common.Entities.NorthwindContext _context;

        public AddModel(Common.Entities.NorthwindContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category categories { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Categories == null || categories == null)
            {
                return Page();
            }
            categories.CategoryId = _context.Categories.OrderBy(x=>x.CategoryId).Last().CategoryId + 1;

            _context.Categories.Add(categories);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}