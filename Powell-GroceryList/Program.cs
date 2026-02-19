var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

// Setup the /controller/actionmethod routing
app.MapDefaultControllerRoute();

app.Run();

