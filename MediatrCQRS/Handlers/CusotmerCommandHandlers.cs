using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrCQRS.Data;
using MediatrCQRS.Models;

namespace MediatrCQRS.Handlers
{
    public class CusotmerCommandHandlers : IRequestHandler<CreateCustomerCommand, CustomerViewModel>
    {
        private readonly AppDbContext _context;

        public CusotmerCommandHandlers(AppDbContext context)
        {
            _context = context;
        }

        public Task<CustomerViewModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            Customer entity = new Customer
            {               
                Name = request.Name
            };

            _context.Customers.Add(entity);
            _context.SaveChangesAsync();

            return Task.FromResult(default(CustomerViewModel));
        }
    }
}
