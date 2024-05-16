using CQRS.Application.Models.Identity;

namespace CQRS.Application.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string userId);
    }
}