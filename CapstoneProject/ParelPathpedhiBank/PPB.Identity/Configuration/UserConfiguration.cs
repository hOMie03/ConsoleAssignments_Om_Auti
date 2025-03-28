using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PPB.Domain.Models;

namespace PPB.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.HasData(
                new User
                {
                    Id = "41776008 - 6086 - 1a1b - b923 - 2879a6680b9a",
                    Name = "Om",
                    Email = "om@admin.com",
                    NormalizedEmail = "OM@ADMIN.COM",
                    PasswordHash = hasher.HashPassword(null, "adminOm@03")
                },
                new User
                {
                    Id = "41776008 - 6086 - 1bcd - b923 - 2879a6680b9a",
                    Name = "Sakthish Nadar",
                    Email = "sakthish@hotmail.com",
                    NormalizedEmail = "SAKTHISH@HOTMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "sakT@1234")
                },
                new User
                {
                    Id = "41776008 - 6086 - 1f2e - b923 - 2879a6680b9a",
                    Name = "Shreekant",
                    Email = "shreek@gmail.com",
                    NormalizedEmail = "SHREEK@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "shreeK@4321")
                }

            );
        }
    }
}
