using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrCQRS.Commands;
using MediatrCQRS.Data;
using MediatrCQRS.Models;

namespace MediatrCQRS.Handlers
{
    public class CusotmerCommandHandlers : 
        IRequestHandler<CreateCustomerCommand, CustomerViewModel>,
        IRequestHandler<DeleteCusotmerCommand, bool>
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
    }
}
