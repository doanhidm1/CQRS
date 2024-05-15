using CQRS.Application.Contracts.Persistence;
using CQRS.Domain;
using CQRS.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HRDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsLeaveTypeNameUnique(string name)
        {
            var result = await _dbContext.LeaveTypes
                .AsNoTracking()
                .AnyAsync(lt => lt.Name.Equals(name));
            return !result;
        }

        public async Task<bool> IsLeaveTypeNameUnique(int id, string name)
        {
            var result = await _dbContext.LeaveTypes
                .AsNoTracking()
                .AnyAsync(lt => lt.Name.Equals(name) && lt.Id != id);
            return !result;
        }
    }
}
