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


     public class DeleteModel : PageModel // the class for the deleting methods
    {
        private  Common.Entities.NorthwindContext _context;

        public DeleteModel(Common.Entities.NorthwindContext context) // the same of the other pages
        {
            _context = context;
        }

        [BindProperty]
        public Category categories { get; set; } = default!; // our variable for making changes
        

    


    public async Task<IActionResult> OnGetAsync(int? id) // we automaticly start to delete things hahaha
        {
            if (id == null || _context.Categories == null) // we check if we hace and id, and if the table exist
            {
                return NotFound();
            }

            var cat = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id); // we serch for the fist value that match with thw id we got

            if (cat == null) // check if we find something
            {
                return RedirectToPage("/index"); // if we don't we return to the index, with out deleting nothing
            }
            else 
            {
                categories = cat; 
                _context.Categories.Remove(categories);// we delate that value we find
                try
                {
                    await _context.SaveChangesAsync();// save the changes
                    
                }
                catch (System.Exception)
                {
                    
                    return Page();
                }
                
            }

            return RedirectToPage("/Index"); // finally, we return to the main page
            
           
        }


    }





}
