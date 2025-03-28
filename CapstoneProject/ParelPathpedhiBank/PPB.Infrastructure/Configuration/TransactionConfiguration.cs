using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PPB.Domain.Models;
using PPB.Domain.Models.Constants;

namespace PPB.Infrastructure.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasData(
                new Transaction()
                {
                    Id = 10101,
                    AccountID = 1,
                    TType = TransactionTypes.Credit,
                    Amount = 10000,
                    Date = new DateTime(2025, 03, 28),
                    Description = "Salary Credited"
                },
                new Transaction()
                {
                    Id = 10102,
                    AccountID = 2,
                    TType = TransactionTypes.Debit,
                    Amount = 5000,
                    Date = new DateTime(2025, 03, 30),
                    Description = "Dinner"
                }
            );
        }
    }
}
