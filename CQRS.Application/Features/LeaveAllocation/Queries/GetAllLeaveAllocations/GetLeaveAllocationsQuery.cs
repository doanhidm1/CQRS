using MediatR;

namespace CQRS.Application.Features.LeaveAllocation.Queries
{
    public class GetLeaveAllocationsQuery : IRequest<List<LeaveAllocationDTO>>
    {
    }
}
