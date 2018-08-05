using MediatR;
using MediatrCQRS.Models;

namespace MediatrCQRS.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerViewModel>
    {        
        public string Name { get; set; }
    }
}
