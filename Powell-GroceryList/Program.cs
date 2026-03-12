using Powell_GroceryList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(serviceProvider => new GroceryDatabaseContext(string.Empty));

var app = builder.Build();

app.UseStaticFiles();

// Setup the /controller/actionmethod routing
app.MapDefaultControllerRoute();

app.Run();

