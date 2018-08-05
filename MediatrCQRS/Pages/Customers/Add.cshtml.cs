using System.Threading.Tasks;
using MediatrCQRS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using MediatrCQRS.Commands;

namespace MediatrCQRS.Pages.Customers
{
    public class AddModel : PageModel
    {

        public IMediator _mediator;
        public Customer Customer { get; set; }

        public AddModel(IMediator mediator)
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