using MediatR;

namespace CQRS.Application.Features.LeaveType.Queries
{
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDTO>>;
}
