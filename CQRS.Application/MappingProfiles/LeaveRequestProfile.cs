using AutoMapper;
using CQRS.Application.Features.LeaveRequest.Commands;
using CQRS.Application.Features.LeaveRequest.Queries;
using CQRS.Domain;

namespace CQRS.Application.MappingProfiles
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequestDTO, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDetailDTO>();
            CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
            CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
        }
    }
}
