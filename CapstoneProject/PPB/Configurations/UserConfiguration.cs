using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PPB.Models;

namespace PPB.Configurations
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
                    Id = "41776008 - 6086 - 1fcd - b923 - 2879a6680b9a",
                    Name = "Sakthish Nadar",
                    Email = "sakthish@hotmail.com",
                    NormalizedEmail = "SAKTHISH@HOTMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "sakT@1234")
                }
            );
        }
    }
}
