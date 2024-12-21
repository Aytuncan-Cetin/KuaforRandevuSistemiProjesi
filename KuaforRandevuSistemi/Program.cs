using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity servisini ekliyoruz ve gerekli kimlik do�rulama ve yetkilendirme i�lemlerini yap�land�r�yoruz.
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Kullan�c� rollerini ve admin kullan�c�y� olu�turuyoruz.
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    context.Database.EnsureCreated();

    if (!roleManager.RoleExistsAsync("Admin").Result)
    {
        var role = new IdentityRole { Name = "Admin" };
        var result = roleManager.CreateAsync(role).Result;
    }

    if (userManager.FindByEmailAsync("admin@example.com").Result == null)
    {
        var user = new IdentityUser
        {
            UserName = "admin@example.com",
            Email = "admin@example.com"
        };

        var userResult = userManager.CreateAsync(user, "Admin@123").Result;

        if (userResult.Succeeded)
        {
            userManager.AddToRoleAsync(user, "Admin").Wait();
        }
    }
}

// HTTP istek i�leme hatt�n� yap�land�r�yoruz.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
