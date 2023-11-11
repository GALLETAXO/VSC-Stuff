using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Northwind.Pages.Categories;

public class IndexModel : PageModel
{
    private  Common.Entities.NorthwindContext _context;

    public IndexModel(Common.Entities.NorthwindContext context)
    {
        _context = context;
    }

    public IList<Category> categories { get;set; }  = default!;


    public async Task OnGetAsync()
    {
        if (_context.Categories != null)
        {
            categories = await _context.Categories.ToListAsync();
        }
    }


}