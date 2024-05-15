using MediatR;

namespace CQRS.Application.Features.LeaveRequest.Queries
{
    public class GetLeaveRequestDetailQuery : IRequest<LeaveRequestDetailDTO>
    {
        public int Id { get; set; }
    }
}
