using Microsoft.AspNetCore.Identity;
using SampleBlog.Core.Domain.Identity;

namespace SampleBlog.Infrastructure
{
    public class DataSeeder
    {
        public async Task SeedAsync(SampleBlogContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            var rootAdminRoleId = Guid.NewGuid();
            if(!context.Roles.Any())
            {
                await context.Roles.AddAsync(new AppRole()
                {
                    Id = rootAdminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin",
                    DisplayName = "Administrator"
                });
                await context.SaveChangesAsync();

                if (!context.Users.Any())
                {
                    var userId = Guid.NewGuid();
                    var user = new AppUser()
                    {
                        Id = userId,
                        FirstName = "Hao",
                        LastName = "Truong",
                        Email = "truongdinhquochao@gmail.com",
                        NormalizedEmail = "truongdinhquochao@gmail.com",
                        IsActive = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        LockoutEnabled = false,
                        DateCreated = DateTime.Now
                    };

                    user.PasswordHash = passwordHasher.HashPassword(user, "admin");
                    await context.Users.AddAsync(user);

                    await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                    {
                        RoleId = rootAdminRoleId,
                        UserId = userId,
                    });
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
