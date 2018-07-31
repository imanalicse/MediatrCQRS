using MediatR;

namespace MediatrCQRS.Models
{
    public class CreateCustomerCommand : IRequest<CustomerViewModel>
    {        
        public string Name { get; set; }
    }
}
