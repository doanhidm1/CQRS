using CQRS.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Identity.DatabaseContext
{
    public class HRIdentityDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public HRIdentityDatabaseContext(DbContextOptions<HRIdentityDatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                if (tableName == null) continue;
                if (tableName.StartsWith("AspNet"))
                {
                    entity.SetTableName(tableName.Substring(6));
                }
            }

            builder.ApplyConfigurationsFromAssembly(typeof(HRIdentityDatabaseContext).Assembly);
        }
    }
}