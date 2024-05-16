using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "4fc27ac3-b094-48d5-8c7a-8864633e1090",
                    UserId = "f630f8c1-bc29-43b8-bb14-186a9e236d5a"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "a0f6df4e-e8df-43c5-934f-7371838a0584",
                    UserId = "10bbf84f-f83b-444f-9d92-0c4b3da26b94"
                }
            );
        }
    }
}