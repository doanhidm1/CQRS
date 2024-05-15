using CQRS.Application.Contracts.Persistence;
using CQRS.Domain;
using CQRS.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HRDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                .AsNoTracking()
                .Include(lr => lr.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            var leaveRequests = await _dbContext.LeaveRequests
                .AsNoTracking()
                .Where(lr => lr.RequestingEmployeeId.Equals(userId))
                .Include(lr => lr.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest?> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .AsNoTracking()
                .Include(lr => lr.LeaveType)
                .FirstOrDefaultAsync(lr => lr.Id == id);
            return leaveRequest;
        }
    }
}
