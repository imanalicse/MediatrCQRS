using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatrCQRS.Data;
using MediatrCQRS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;

namespace MediatrCQRS.Pages.Customers
{
    public class AddModel : PageModel
    {

        public IMediator _mediator;
        public Customer Customer { get; set; }

        public AddModel(AppDbContext context, IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnPostAsync(CreateCustomerCommand Customer)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _mediator.Send(Customer);            

            return RedirectToPage("./Index");
        }
    }  
}