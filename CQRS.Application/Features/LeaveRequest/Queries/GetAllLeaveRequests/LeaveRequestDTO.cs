using CQRS.Application.Features.LeaveType.Queries;

namespace CQRS.Application.Features.LeaveRequest.Queries
{
    public class LeaveRequestDTO
    {
        public string RequestingEmployeeId { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
    }
}
