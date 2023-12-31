using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Globalization;
using WebProgramlama_Odev.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    ;
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Admin/LoginAdmin/";
    });
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
}
);
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] {


        new CultureInfo("tr-TR"),

        new CultureInfo("en-US")

};

    options.DefaultRequestCulture = new RequestCulture("tr-TR");
    options.SupportedUICultures = supportedCultures;

});






var app = builder.Build();

app.UseRequestLocalization();

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
app.UseSession();

app.UseAuthorization();
app.UseAuthentication();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Guzergah}/{action=Index}/{id?}");

app.Run();
