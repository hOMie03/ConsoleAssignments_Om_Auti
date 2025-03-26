using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PPB.Configurations;

namespace PPB.Context
{
    public class PPBDBContext : IdentityDbContext
    {
        public PPBDBContext(DbContextOptions<PPBDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
