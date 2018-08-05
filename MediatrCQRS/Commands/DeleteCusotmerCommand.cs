using MediatR;

namespace MediatrCQRS.Commands
{
    public class DeleteCusotmerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
