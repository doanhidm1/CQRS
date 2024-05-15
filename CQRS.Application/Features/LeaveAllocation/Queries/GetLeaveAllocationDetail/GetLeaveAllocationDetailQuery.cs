using MediatR;

namespace CQRS.Application.Features.LeaveAllocation.Queries
{
    public class GetLeaveAllocationDetailQuery : IRequest<LeaveAllocationDetailDTO>
    {
        public int Id { get; set; }
    }
}