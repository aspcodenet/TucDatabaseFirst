using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TucDatabaseFirst.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            context.Database.Migrate();
            SeedRoles(context);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("stefan.holmberg@systementor.se").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "stefan.holmberg@systementor.se";
                user.Email = "stefan.holmberg@systementor.se";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Hejsan123#").Result;
                userManager.AddToRoleAsync(user, "Admin").Wait();

            }
            if (userManager.FindByEmailAsync("johan.garpenlov@trekronor.se").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "johan.garpenlov@trekronor.se";
                user.Email = "johan.garpenlov@trekronor.se";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Hejsan123#").Result;
                userManager.AddToRoleAsync(user, "Coach").Wait();

            }

        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                context.Roles.Add(new IdentityRole {
                    NormalizedName = "Admin",
                    Name = "Admin"
                });
            }
            if (!context.Roles.Any(r => r.Name == "Coach"))
            {
                context.Roles.Add(new IdentityRole
                {
                    NormalizedName = "Coach",
                    Name = "Coach"
                });
            }

            context.SaveChanges();
        }
    }
}