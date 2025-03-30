using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PPB.Domain.Models.Constants;
using PPB.Domain.Models;

namespace PPB.Infrastructure.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
                new Account()
                {
                    Id = 1,
                    UserID = "41776008 - 6086 - 1f2e - b923 - 2879a6680b9a",
                    AccountNumber = 12345678,
                    Balance = 20000,
                    AccountType = AccountTypes.Salary,
                    CreatedDate = new DateTime(2020, 12, 03)
                },
                new Account()
                {
                    Id = 2,
                    UserID = "41776008 - 6086 - 1bcd - b923 - 2879a6680b9a",
                    AccountNumber = 87654321,
                    Balance = 20000,
                    AccountType = AccountTypes.Savings,
                    CreatedDate = new DateTime(2025, 01, 10)
                }
            );
        }
    }
}
