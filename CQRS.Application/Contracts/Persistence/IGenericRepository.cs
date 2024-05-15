using CQRS.Domain.Common;

namespace CQRS.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
#nullable enable
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}