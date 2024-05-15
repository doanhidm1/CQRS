using MediatR;

namespace CQRS.Application.Features.LeaveAllocation.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public int LeaveTypeId { get; set; }
    }
}
