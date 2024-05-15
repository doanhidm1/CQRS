using MediatR;

namespace CQRS.Application.Features.LeaveAllocation.Commands
{
    public class DeleteLeaveAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
