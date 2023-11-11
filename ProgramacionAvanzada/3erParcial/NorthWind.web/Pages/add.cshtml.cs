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
    public class AddModel : PageModel // the class that is focus in adding new categories
    {
        private  Common.Entities.NorthwindContext _context; // the same thing that in the index

        public AddModel(Common.Entities.NorthwindContext context) // we get the context of the database, so we can use it in the rest of the code
        {
            _context = context;
        }


        public IActionResult OnGet() // we don't need to do nothing when we arrive so, well wait
        {
            return Page();
        }

        [BindProperty]
        public Category categories { get; set; } = default!; // in this case we only need a variable of the category type
        

        public async Task<IActionResult> OnPostAsync() // here, this part start to work when the user submit the data, also as a Task<IActionResult> type, it will make the action we return
        {
          if (!ModelState.IsValid || _context.Categories == null || categories == null) // here we inspect if we can proceed with out causing an error
            {
                return Page(); // if we make a mistake, we reload the page
            }
            categories.CategoryId = _context.Categories.OrderBy(x=>x.CategoryId).Last().CategoryId + 1; // here, this is a little mess, it looks like the database does not has an AutoIncrement
            // or my way to introduce my new data is strange, thats whym first I give category an id, we find the CategoryId of the last elemt in the table, then i add it a 1

            _context.Categories.Add(categories); // we add categories to the database
            await _context.SaveChangesAsync(); //we save the changes

            return RedirectToPage("/Index"); // here we return to the main page
        }
    }
}