using MediatR;
using MediatrCQRS.Models;

namespace MediatrCQRS.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
