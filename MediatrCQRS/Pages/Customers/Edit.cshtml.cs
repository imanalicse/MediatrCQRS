using System;
using System.Collections.Generic;
using System.Linq;
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
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        [BindProperty]
        public Customer Customer { get; set; }

        public EditModel(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var query = new GetCustomerByIdQuery { Id = id };
            Customer = await _mediator.Send(query);

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