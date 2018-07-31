using System.Collections.Generic;
using System.Threading.Tasks;
using MediatrCQRS.Data;
using MediatrCQRS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MediatrCQRS.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IList<Customer> Customers { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if(customer != null)
            {
                _context.Customers.Remove(customer);
               await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}