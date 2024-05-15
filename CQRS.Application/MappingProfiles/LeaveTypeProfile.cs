using AutoMapper;
using CQRS.Application.Features.LeaveType.Commands;
using CQRS.Application.Features.LeaveType.Queries;
using CQRS.Domain;

namespace CQRS.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDTO, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailDTO>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }
    }
}
