using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// that's a lot of libraries :0

namespace Northwind.Pages.Categories; 

public class IndexModel : PageModel // our class, we put here the methods and things we are going to use later un the cshtml
{
    private  Common.Entities.NorthwindContext _context; // first, we obtain the context about our database using our NorthwindContext.cs, using this we can get access to 
    // the collumns of the database we declared in that file

    public IndexModel(Common.Entities.NorthwindContext context) // our constructor, with it, we can use the database with oue methods and varables
    {
        _context = context;
    }

    public IList<Category> categories { get;set; }  = default!; // a list, here we save the data from the table category


    public async Task OnGetAsync() // this is one of the fist things the page does, we use this to make a list we can use later in the html to make a table with the data
    {
        if (_context.Categories != null) // first we check if it is any information in the table, if we hava some, we put it in our list
        {
            categories = await _context.Categories.ToListAsync();
        }
    }


}