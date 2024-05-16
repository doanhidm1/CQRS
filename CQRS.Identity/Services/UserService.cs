using CQRS.Application.Exceptions;
using CQRS.Application.Identity;
using CQRS.Application.Models.Identity;
using CQRS.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CQRS.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Employee> GetEmployee(string userId)
        {
            var e = await _userManager.FindByIdAsync(userId);
            if (e == null)
            {
                throw new NotFoundException($"Employee with id {userId} does not exist", userId);
            }
            return new Employee
            {
                Id = e.Id,
                Email = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName,
            };
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(e => new Employee
            {
                Id = e.Id,
                Email = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName,
            }).ToList();
        }
    }
}
