using MediatR;

namespace CQRS.Application.Features.LeaveType.Queries
{
    public record GetLeaveTypeDetailQuery(int Id) : IRequest<LeaveTypeDetailDTO>;
}
