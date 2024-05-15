using CQRS.Domain;

namespace CQRS.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeNameUnique(string name);
        Task<bool> IsLeaveTypeNameUnique(int id, string name);
    }
}