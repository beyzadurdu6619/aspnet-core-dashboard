using DataAccessLayer.Concrete;
using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lam�n� ekle
builder.Services.AddDbContext<Context>();

// ASP.NET Identity yap�land�rmas�
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
})
.AddEntityFrameworkStores<Context>()
.AddErrorDescriber<CustomIdentityValidator>()
.AddDefaultTokenProviders();

// Yetkilendirme politikas�
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Kimlik do�rulama �erez ayarlar�
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index"; // Yetkisiz kullan�c�lar buraya y�nlendirilecek
    options.AccessDeniedPath = "/Login/AccessDenied"; // Yetki eksikse buraya y�nlendirilir
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturum s�resi
    options.SlidingExpiration = true; // Kullan�c� aktifse s�re yenilensin
    options.Cookie.HttpOnly = true; // G�venlik i�in HTTP-only �erez kullan�m�
});


// Uygulamay� olu�tur
var app = builder.Build();

// Hata sayfas� y�nlendirmesi (Production modunda �al���r)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware s�ras�
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // �nce kimlik do�rulama
app.UseAuthorization();  // Sonra yetkilendirme

// Varsay�lan rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
