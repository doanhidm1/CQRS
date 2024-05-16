using CQRS.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "f630f8c1-bc29-43b8-bb14-186a9e236d5a",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@localhost",
                    NormalizedEmail = "ADMIN@LOCALHOST",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Doanh@123"),
                    FirstName = "System",
                    LastName = "Admin",
                },
                new ApplicationUser
                {
                    Id = "10bbf84f-f83b-444f-9d92-0c4b3da26b94",
                    UserName = "employee",
                    NormalizedUserName = "EMPLOYEE",
                    Email = "employee@localhost",
                    NormalizedEmail = "EMPLOYEE@LOCALHOST",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Doanh@123"),
                    FirstName = "System",
                    LastName = "Employee",
                }
            );
        }
    }
}
