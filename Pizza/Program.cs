using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Pizza.Domain.IService;
using Pizza.Domain.JWTAuth;
using Pizza.Domain.Repositories;
using Pizza.Domain.Repositories.Factories;
using Pizza.Domain.Service;
using Pizza.Models.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddAuthorization();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddDbContext<PizzaProjectContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IPromoService, PromoService>();
builder.Services.AddTransient<IBusketService, BusketService>();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute
    (
        name : "default",
        pattern : "{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute
    (
        name: "Areas",
        pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
    );
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseSession();

app.Run();


