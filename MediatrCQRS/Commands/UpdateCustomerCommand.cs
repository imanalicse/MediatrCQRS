using MediatrCQRS.Models;
using MediatR;

namespace MediatrCQRS.Commands
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
