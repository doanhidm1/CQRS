using AutoMapper;
using CQRS.Application.Contracts.Persistence;
using CQRS.Application.Exceptions;
using MediatR;

namespace CQRS.Application.Features.LeaveType.Queries
{
    public class GetLeaveTypeDetailQueryHandler : IRequestHandler<GetLeaveTypeDetailQuery, LeaveTypeDetailDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDetailDTO> Handle(GetLeaveTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }
            var data = _mapper.Map<LeaveTypeDetailDTO>(leaveType);
            return data;
        }
    }
}
