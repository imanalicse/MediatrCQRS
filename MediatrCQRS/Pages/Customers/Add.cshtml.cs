using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatrCQRS.Data;
using MediatrCQRS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediatrCQRS.Pages.Customers
{
    public class AddModel : PageModel
    {
        public readonly AppDbContext _context;

        public Customer Customer { get; set; }

        public AddModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(Customer Customer)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
           await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }  
}