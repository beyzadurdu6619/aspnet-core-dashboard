using DataAccessLayer.Concrete;
using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlamýný ekle
builder.Services.AddDbContext<Context>();

// ASP.NET Identity yapýlandýrmasý
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
})
.AddEntityFrameworkStores<Context>()
.AddErrorDescriber<CustomIdentityValidator>()
.AddDefaultTokenProviders();

// Yetkilendirme politikasý
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Kimlik doðrulama çerez ayarlarý
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index"; // Yetkisiz kullanýcýlar buraya yönlendirilecek
    options.AccessDeniedPath = "/Login/AccessDenied"; // Yetki eksikse buraya yönlendirilir
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturum süresi
    options.SlidingExpiration = true; // Kullanýcý aktifse süre yenilensin
    options.Cookie.HttpOnly = true; // Güvenlik için HTTP-only çerez kullanýmý
});


// Uygulamayý oluþtur
var app = builder.Build();

// Hata sayfasý yönlendirmesi (Production modunda çalýþýr)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware sýrasý
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Önce kimlik doðrulama
app.UseAuthorization();  // Sonra yetkilendirme

// Varsayýlan rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
