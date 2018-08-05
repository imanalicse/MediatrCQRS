using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatrCQRS.Data;
using MediatrCQRS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MediatrCQRS.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Customer Customer { get; set; }

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _context.Customers.FindAsync(id);            
            if (Customer == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception($"Customer {Customer.Id} not found", e);
            }

            return RedirectToPage("./Index");
        }

    }
}