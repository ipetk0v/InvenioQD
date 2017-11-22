using CameraBazaar.Web.Infrastructures.Constants;
using Invenio.Data;
using Invenio.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CameraBazaar.Web.Infrastructures.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDataBaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<InvenioDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    var adminName = GlobalConstants.GeneralManager;

                    var roleExist = await roleManager.RoleExistsAsync(adminName);

                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminName

                        });
                    }

                    var adminEmail = "admin@abv.bg";
                    var adminUserExist = await userManager.FindByEmailAsync(adminEmail);

                    if (adminUserExist == null)
                    {
                        var adminUser = new User
                        {
                            Email = adminEmail,
                            UserName = "Admin"
                        };

                        await userManager.CreateAsync(adminUser, "admin123");

                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }

                }).GetAwaiter()
                .GetResult();
            }

            return app;
        }
    }
}
