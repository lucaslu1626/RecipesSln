using Microsoft.EntityFrameworkCore;
using RecipesApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts => {
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:RecipesAppConnection"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute("pagination", "Recipes/Page{recipePage}", new { Controller = "Home", action = "Index" });
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
//app.MapFallback();

SeedData.EnsurePopulated(app);

app.Run();
