using CQRS.Domain;

namespace CQRS.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
#nullable enable
        Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId);
        Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
        Task AddAllocations(List<LeaveAllocation> leaveAllocations);
        Task<LeaveAllocation?> GetUserAllocation(string userId, int leaveTypeId);
    }
}