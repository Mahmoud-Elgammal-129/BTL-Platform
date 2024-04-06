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
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<InventoryRepository>();
builder.Services.AddScoped<PlacesRepository>();
builder.Services.AddScoped<UnitRepository>();
builder.Services.AddScoped<UnitTypeRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=login}/{action=login}/{id?}");

app.Run();
