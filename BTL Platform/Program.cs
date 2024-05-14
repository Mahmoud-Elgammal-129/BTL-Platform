using BTL_Platform.Models;
using BTL_Platform.Reposatiory;
using BTL_Platform.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BTLContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDB"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<BTLContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<RequestRepository>();
builder.Services.AddScoped<RequestTypeRepository>();

builder.Services.AddScoped<InventoryRepository>();
builder.Services.AddScoped<PlacesRepository>();
builder.Services.AddScoped<UnitRepository>();
builder.Services.AddScoped<UnitTypeRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<VisitRepository>();
builder.Services.AddScoped<VisitStatusRepository>();
builder.Services.AddScoped<VisitTypeRepository>();
builder.Services.AddScoped<UnitDetailRepository>();
builder.Services.AddScoped<PlacesDetailRepository>();
builder.Services.AddScoped<VisitDetailRepository>();



builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddSession(options =>
{
    // Optional: Configure session options (e.g., cookie name, expiration)
    options.Cookie.HttpOnly = true; // Recommended for security
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=login}/{action=login}/{id?}");

app.Run();
