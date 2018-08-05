using MediatR;
using MediatrCQRS.Models;
using System.Collections.Generic;

namespace MediatrCQRS.Queries
{
    public class GetCustomerQuery : IRequest<IEnumerable<CustomerViewModel>>
    {
    }
}
