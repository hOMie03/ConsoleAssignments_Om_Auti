using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PPB.Identity.Configuration;

namespace PPB.Identity.Context
{
    internal class PPBDBIdentityContext : IdentityDbContext
    {
        public PPBDBIdentityContext(DbContextOptions<PPBDBIdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
