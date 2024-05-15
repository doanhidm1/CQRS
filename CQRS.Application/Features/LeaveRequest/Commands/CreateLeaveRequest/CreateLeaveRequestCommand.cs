using CQRS.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace CQRS.Application.Features.LeaveRequest.Commands
{
    public class CreateLeaveRequestCommand : BaseLeaveRequest, IRequest<int>
    {
        public string RequestComments { get; set; } = string.Empty;
    }
}