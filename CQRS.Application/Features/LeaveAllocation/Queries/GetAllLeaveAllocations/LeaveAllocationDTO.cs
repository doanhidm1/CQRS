using CQRS.Application.Features.LeaveType.Queries;

namespace CQRS.Application.Features.LeaveAllocation.Queries
{
    public class LeaveAllocationDTO
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
