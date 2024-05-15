using CQRS.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace CQRS.Application.Features.LeaveRequest.Commands
{
    public class UpdateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
    {
        public int Id { get; set; }
        public string RequestComments { get; set; } = string.Empty;
        public bool Cancelled { get; set; }
    }
}
