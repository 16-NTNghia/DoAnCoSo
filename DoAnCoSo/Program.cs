using DoAnCoSo.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
AddCookie(options =>
{
	options.Cookie.Name = "DEVOITURECookie";
	options.LoginPath = "/User/Login";

	options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
	options.Cookie.MaxAge = options.ExpireTimeSpan; // optional
	options.SlidingExpiration = true;
});

var connectionString = builder.Configuration.GetConnectionString("QuanLyThueXeConnection");
builder.Services.AddDbContext<QuanLyThueXeContext>(options => options.UseSqlServer(connectionString));

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
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
