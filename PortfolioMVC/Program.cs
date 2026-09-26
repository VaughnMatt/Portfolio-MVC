using Microsoft.EntityFrameworkCore;
using PortfolioMVC.Data;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Add SQLite + Entity Framework Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlite(
builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Enable CSS, JavaScript, images, etc.
app.UseStaticFiles();

app.UseRouting();

// Enable Session
app.UseSession();

// Enable Authorization
app.UseAuthorization();

// Default MVC route
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();