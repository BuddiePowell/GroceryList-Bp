using Microsoft.EntityFrameworkCore;
using Powell_GroceryList.Models;
using Powell_GroceryList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// builder.Services.AddScoped<IGroceryRepository>(serviceProvider => new GroceryDatabaseContext(builder.Configuration.GetConnectionString("MySQLConnection")));

builder.Services.AddDbContext<GroceryEntityFrameworkCoreDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("GroceryEntityFrameworkCoreLocalConnection"))
    );

builder.Services.AddScoped<IGroceryRepository, GroceryEntityFrameworkCoreDbContext>();

var app = builder.Build();

app.UseStaticFiles();

// Setup the /controller/actionmethod routing
app.MapDefaultControllerRoute();

app.Run();

