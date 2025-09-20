using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace HotelProject.WebUI.Extensions
{
    public static class IdentityExtensions
    {
        public static async Task<IApplicationBuilder> SeedRolesAndAdminAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

                // Admin rolü oluştur
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new AppRole { Name = "Admin" });
                }

                // User rolü oluştur
                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new AppRole { Name = "User" });
                }

                // Default admin kullanıcısı oluştur
                var adminEmail = "admin@hotel.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);

                if (adminUser == null)
                {
                    adminUser = new AppUser
                    {
                        Name = "Admin",
                        Surname = "User",
                        UserName = "admin",
                        Email = adminEmail,
                        EmailConfirmed = true,
                        City = "İstanbul"
                    };

                    var result = await userManager.CreateAsync(adminUser, "Admin123!");

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
                else
                {
                    // Mevcut admin kullanıcısına admin rolü ekle (eğer yoksa)
                    if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                    {
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding roles and admin user");
            }

            return app;
        }
    }
}