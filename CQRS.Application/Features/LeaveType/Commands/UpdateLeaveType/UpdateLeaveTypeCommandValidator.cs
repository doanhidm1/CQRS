using CQRS.Application.Contracts.Persistence;
using FluentValidation;

namespace CQRS.Application.Features.LeaveType.Commands
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(LeaveTypeExists)
                .WithMessage("LeaveType does not exist.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters.");

            RuleFor(p => p.DefaultDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");

            RuleFor(p => p)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("LeaveType name already exists.");
        }

        private async Task<bool> LeaveTypeExists(UpdateLeaveTypeCommand command, CancellationToken token)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(command.Id);
            return leaveType != null;
        }

        private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
        {
            return await _leaveTypeRepository.IsLeaveTypeNameUnique(command.Id, command.Name);
        }
    }
}
