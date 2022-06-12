using Microsoft.EntityFrameworkCore;
using RecipesApp.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts => {
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:RecipesAppConnection"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(
builder.Configuration["ConnectionStrings:IdentityRecipeConnection"]));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.Configure<IdentityOptions>(opts => {
    opts.Password.RequiredLength = 10;
    opts.Password.RequireNonAlphanumeric = true;
    opts.Password.RequireLowercase = true;
    opts.Password.RequireUppercase = true;
    opts.Password.RequireDigit = true;
    opts.User.RequireUniqueEmail = true;
    opts.User.AllowedUserNameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("catpage", "{category}/Page{recipePage:int}", new { Controller = "Home", action = "Index" });
app.MapControllerRoute("page", "Page{recipePage:int}", new { Controller = "Home", action = "Index", recipePage = 1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", action = "Index", recipePage = 1 });
app.MapControllerRoute("pagination", "Recipes/Page{recipePage}", new { Controller = "Home", action = "Index", recipePage = 1 });
app.MapControllerRoute("forms", "controllers/{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute("pagination", "Recipes/Page{recipePage}", new { Controller = "Home", action = "Index" });
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
//app.MapFallback();

SeedData.EnsurePopulated(app);
IdentitySeedData.CreateAdminAccount(app.Services, app.Configuration);

app.Run();
