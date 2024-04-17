using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogMe.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //seed roles - user, admin and superadmin

            var adminRoleId = "336f9cb4-edaa-4013-96fe-bd10d832c9e3";
            var userRoleId = "9f2a908c-2790-4698-8bef-af0c7b30923e";
            var superAdminRoleId = "3707b455-422b-481d-9313-79d1eb68aebe";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp=adminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId

                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            //seed super admin user

            var superAdminUserId = "9b1b9636-35d5-49b7-a86c-455dbdbd8de6";

            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@blogme.com",
                Email = "superadmin@blogme.com",
                NormalizedEmail = "superadmin@blogme.com".ToUpper(),
                Id = superAdminUserId,
                NormalizedUserName = "superadmin@blogme.com"
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().
                HashPassword(superAdminUser, "Sathya99#");

            builder.Entity<IdentityUser>().HasData(superAdminUser);



            //add all roles to SA

            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminUserId
                },
                 new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminUserId
                },
                  new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminUserId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
