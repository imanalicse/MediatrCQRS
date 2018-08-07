using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrCQRS.Commands;
using MediatrCQRS.Data;
using MediatrCQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatrCQRS.Handlers
{
    public class CusotmerCommandHandlers :
        IRequestHandler<CreateCustomerCommand, CustomerViewModel>,
        IRequestHandler<DeleteCusotmerCommand, bool>,
        IRequestHandler<UpdateCustomerCommand, bool>
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

        public Task<bool> Handle(DeleteCusotmerCommand request, CancellationToken cancellationToken)
        {
            var customer = _context.Customers.Find(request.Id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChangesAsync();
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer newCustomer = new Customer
            {
                Id = request.Id,
                Name = request.Name
            };

            _context.Attach(newCustomer).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}
