using CQRS.Application.Contracts.Persistence;
using CQRS.Application.Features.LeaveRequest.Shared;
using FluentValidation;

namespace CQRS.Application.Features.LeaveRequest.Commands
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new BaseLeaveRequestValidator(_leaveTypeRepository));
        }
    }
}
