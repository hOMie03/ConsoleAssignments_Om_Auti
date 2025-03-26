using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PPB.Identity.Configuration;

namespace PPB.Identity.Context
{
    public class PPBIdentityDBContext : IdentityDbContext
    {
        public PPBIdentityDBContext(DbContextOptions<PPBIdentityDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
