using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DAL;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        List<IdentityRole> roles = new List<IdentityRole>{
            new IdentityRole {Name = AppRole.Admin, NormalizedName = AppRole.Admin.ToUpper()},
            new IdentityRole {Name = AppRole.User, NormalizedName = AppRole.User.ToUpper()},
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);

        List<AppUser> users = new List<AppUser>{
            new AppUser{
                UserName="admin",
                NormalizedUserName="ADMIN",
                Email="admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM"
            },
            new AppUser{
                UserName="user",
                NormalizedUserName="USER",
                Email="user@user.com",
                NormalizedEmail="USER@USER.COM"
            }
        };
        modelBuilder.Entity<AppUser>().HasData(users);

        var passHasher = new PasswordHasher<AppUser>();
        users[0].PasswordHash = passHasher.HashPassword(users[0], "admin");
        users[1].PasswordHash = passHasher.HashPassword(users[1], "user");

        List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users.First(u => u.NormalizedUserName == "ADMIN").Id,
            RoleId = roles.First(r => r.NormalizedName == "ADMIN").Id
        });
        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users.First(u => u.NormalizedUserName == "USER").Id,
            RoleId = roles.First(r => r.NormalizedName == "USER").Id
        });
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }
}