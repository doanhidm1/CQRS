using AutoMapper;
using CQRS.Application.Features.LeaveAllocation.Commands;
using CQRS.Application.Features.LeaveAllocation.Queries;
using CQRS.Domain;

namespace CQRS.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDTO, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailDTO>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}
