using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PPB.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "41776008 - 6086 - 1a1a - b923 - 2879a6680b9a", // Admin
                    UserId = "41776008 - 6086 - 1a1b - b923 - 2879a6680b9a" // Om
                },
                new IdentityUserRole<string>
                {
                    RoleId = "41776008 - 6086 - 1b1b - b923 - 2879a6680b9a", // Banker
                    UserId = "41776008 - 6086 - 1bcd - b923 - 2879a6680b9a" // Sakthish
                },
                new IdentityUserRole<string>
                {
                    RoleId = "41776008 - 6086 - 1fbf - b923 - 2879a6680b9a", // User
                    UserId = "41776008 - 6086 - 1f2e - b923 - 2879a6680b9a" // Shreekant
                }
            );
        }
    }
}
