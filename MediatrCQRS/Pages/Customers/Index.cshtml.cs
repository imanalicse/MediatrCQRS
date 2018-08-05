using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MediatrCQRS.Commands;
using MediatrCQRS.Data;
using MediatrCQRS.Models;
using MediatrCQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public async Task<IActionResult> OnPostDeleteAsync(int id, DeleteCusotmerCommand command)
        {
            command.Id = id;
            var isDeleted = await _mediator.Send(command);
            
            return RedirectToPage();
        }
    }
}