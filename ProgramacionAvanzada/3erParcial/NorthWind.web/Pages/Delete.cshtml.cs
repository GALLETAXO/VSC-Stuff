using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Common.Entities;

namespace Northwind.Pages.Categories
{


     public class DeleteModel : PageModel
    {
        private  Common.Entities.NorthwindContext _context;

        public DeleteModel(Common.Entities.NorthwindContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category categories { get; set; } = default!;
        

    


    public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var cat = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);

            if (cat == null)
            {
                return RedirectToPage("/add");
            }
            else 
            {
                categories = cat;
                _context.Categories.Remove(categories);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
            
           
        }


    }





}
