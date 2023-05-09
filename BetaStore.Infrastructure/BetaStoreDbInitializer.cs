using BetaStore.Domain.Entities;
using BetaStore.Domain.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BetaStore.Infrastructure
{
    public class BetaStoreDbInitializer
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin.ToString()))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString()));
                if (!await roleManager.RoleExistsAsync(UserRoles.Customer.ToString()))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer.ToString()));

                //User
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Customer>>();
                var adminUser = await userManager.FindByEmailAsync("admin@betastore.com");
                if (adminUser == null)
                {
                    var newAdminUser = new Customer()
                    {
                        FullName = "Ainz Oaol Gown",
                        UserName = "Ainz-sama",
                        Email = "admin@betastore.com",
                        Address = "Ainz Ooal Gown's Castle",
                        EmailConfirmed = true,
                        DateCreated = DateTime.Now.AddYears(-3)
                    };
                    newAdminUser.CustomerSince = newAdminUser.DateCreated;
                    await userManager.CreateAsync(newAdminUser, "Nezuko@slayer4");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin.ToString());
                }

                var appUser = await userManager.FindByEmailAsync("user@betastore.com");
                if (appUser == null)
                {
                    var newAppUser = new Customer()
                    {
                        FullName = "Hinata Sakaguchi",
                        UserName = "Hinata",
                        Email = "user@betastore.com",
                        Address = "Holy Empire Ruberios",
                        EmailConfirmed = true,
                        DateCreated = DateTime.Now.AddYears(-2)
                    };
                    newAppUser.CustomerSince = newAppUser.DateCreated;
                    await userManager.CreateAsync(newAppUser, "Hinata@rimuru4");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Customer.ToString());
                }
            }
        }
    }
}
