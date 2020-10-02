using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pix.Domain;

namespace API.Configuration
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser()
                {
                    UserName = "geovane@gmail.com",
                    Email = "geovane@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEI/PRZsDrMWJ/xGHy8bR6pJMJe1VmxqKTgs+ABQOOMW7yoPXe6e0XZGRsfI7bKcorg==",
                    SecurityStamp = "db1d9f13-aa62-4bfd-815d-ccddff4f01e4",
                    ConcurrencyStamp = "1117e94c-55bf-450a-b6d3-cf56fbe647cb",
                    NormalizedEmail = "geovane@gmail.com".ToUpper(),
                    NormalizedUserName = "geovane@gmail.com".ToUpper(),
                }
            );
        }
    }
}
