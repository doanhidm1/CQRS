using AutoMapper;
using CQRS.Application.Contracts.Logging;
using CQRS.Application.Contracts.Persistence;
using CQRS.Application.Exceptions;
using MediatR;

namespace CQRS.Application.Features.LeaveType.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CreateLeaveTypeCommandHandler> _logger;

        public CreateLeaveTypeCommandHandler(
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper,
            IAppLogger<CreateLeaveTypeCommandHandler> logger
            )
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                _logger.LogWarn("Validation Error for CreateLeaveTypeCommand for {0} - {1}", nameof(LeaveType), request.Name);
                throw new BadRequestException("Invalid LeaveType Data.", validationResult);
            }
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
            await _leaveTypeRepository.AddAsync(leaveTypeToCreate);
            return leaveTypeToCreate.Id;
        }
    }
}