using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task Initialize(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        if (!roleManager.RoleExistsAsync("Admin").Result)
        {
            var role = new IdentityRole { Name = "Admin" };
            await roleManager.CreateAsync(role);
        }

        if (userManager.FindByEmailAsync("admin@cetin.com").Result == null)
        {
            var user = new IdentityUser { UserName = "admin@cetin.com", Email = "admin@cetin.com" };
            var result = await userManager.CreateAsync(user, "Admin123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
