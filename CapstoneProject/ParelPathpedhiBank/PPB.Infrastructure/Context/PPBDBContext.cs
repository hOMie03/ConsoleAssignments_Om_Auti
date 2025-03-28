using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using PPB.Domain.Models;
using PPB.Infrastructure.Configuration;

namespace PPB.Infrastructure.Context
{
    public class PPBDBContext : DbContext
    {
        public PPBDBContext(DbContextOptions<PPBDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            //modelBuilder.Entity("AspNetUsers").HasMany("Accounts");
            //modelBuilder.Entity("Accounts").HasMany("Transactions");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Domain.Models.Transaction> Transactions { get; set; }
    }
}
