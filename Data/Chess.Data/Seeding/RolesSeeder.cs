namespace Chess.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Chess.Common;
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Data.Seeding;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ChessDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedRoleAsync(roleManager, userManager, GlobalConstants.AdministratorRoleName);
        }

        private static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }

            if (!await userManager.Users.AnyAsync())
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,                   
                };

                var password = "123456";

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                }
            }
        }
    }
}