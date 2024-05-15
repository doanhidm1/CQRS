using MediatR;

namespace CQRS.Application.Features.LeaveRequest.Commands
{
    public class DeleteLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
