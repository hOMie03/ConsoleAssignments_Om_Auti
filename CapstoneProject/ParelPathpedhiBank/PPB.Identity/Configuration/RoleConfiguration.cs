using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PPB.Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "41776008 - 6086 - 1a1a - b923 - 2879a6680b9a",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "41776008 - 6086 - 1b1b - b923 - 2879a6680b9a",
                    Name = "Banker",
                    NormalizedName = "BANKER"
                },
                new IdentityRole
                {
                    Id = "41776008 - 6086 - 1fbf - b923 - 2879a6680b9a",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
