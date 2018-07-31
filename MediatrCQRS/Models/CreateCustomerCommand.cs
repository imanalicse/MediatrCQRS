using MediatR;

namespace MediatrCQRS.Models
{
    public class CreateCustomerCommand : IRequest<CustomerViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
