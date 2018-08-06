using MediatR;
using MediatrCQRS.Data;
using MediatrCQRS.Models;
using MediatrCQRS.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrCQRS.Handlers
{
    public class CustomerQueryHandlers :
        IRequestHandler<GetCustomerQuery, IEnumerable<CustomerViewModel>>,
        IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly AppDbContext _context;

        public CustomerQueryHandlers(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<CustomerViewModel>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var entities = _context.Customers
                .AsNoTracking()
                .Select(x => new CustomerViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            if (entities != null)
            {
                return Task.FromResult(entities.AsEnumerable());
            }

            return Task.FromResult(Enumerable.Empty<CustomerViewModel>());
        }

        public Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {

            var entity = _context.Customers.Find(request.Id);
            if (entity != null)
            {                
                return Task.FromResult(entity);
            }

            return Task.FromResult(default(Customer));
        }
    }
}
