using CQRS.Application.Contracts.Persistence;
using CQRS.Domain;
using CQRS.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HRDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> leaveAllocations)
        {
            await _dbContext.LeaveAllocations.AddRangeAsync(leaveAllocations);
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _dbContext.LeaveAllocations
                .AsNoTracking()
                .AnyAsync(la => la.EmployeeId.Equals(userId) &&
                la.LeaveTypeId == leaveTypeId && la.Period == period);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                .AsNoTracking()
                .Include(la => la.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                .AsNoTracking()
                .Where(la => la.EmployeeId.Equals(userId))
                .Include(la => la.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
                .AsNoTracking()
                .Include(la => la.LeaveType)
                .FirstOrDefaultAsync(la => la.Id == id);
            return leaveAllocation;
        }

        public async Task<LeaveAllocation?> GetUserAllocation(string userId, int leaveTypeId)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
                .AsNoTracking()
                .FirstOrDefaultAsync(la => la.EmployeeId.Equals(userId) &&
                                            la.LeaveTypeId == leaveTypeId);
            return leaveAllocation;
        }
    }
}
