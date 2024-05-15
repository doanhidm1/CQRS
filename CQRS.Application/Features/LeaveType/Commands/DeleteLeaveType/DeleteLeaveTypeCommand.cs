using MediatR;

namespace CQRS.Application.Features.LeaveType.Commands
{
    public record DeleteLeaveTypeCommand(int Id) : IRequest<Unit>;
}