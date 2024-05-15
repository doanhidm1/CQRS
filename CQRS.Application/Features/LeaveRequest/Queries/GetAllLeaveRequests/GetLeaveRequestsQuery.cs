using MediatR;

namespace CQRS.Application.Features.LeaveRequest.Queries
{
    public class GetLeaveRequestsQuery : IRequest<List<LeaveRequestDTO>>
    {
    }
}