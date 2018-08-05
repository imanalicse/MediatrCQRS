using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MediatrCQRS.Data;
using MediatrCQRS.Models;
using MediatrCQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MediatrCQRS.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public IEnumerable<CustomerViewModel> Customers { get; set; }

        public IndexModel(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task OnGetAsync(GetCustomerQuery query)
        {
            Customers = await _mediator.Send(query);
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