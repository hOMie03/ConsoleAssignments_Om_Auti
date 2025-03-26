using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPB.Domain.Models;

namespace PPB.Infrastructure.Context
{
    internal class PPBDBContext : DbContext
    {
        public PPBDBContext(DbContextOptions<PPBDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
