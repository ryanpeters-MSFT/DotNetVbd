using Microsoft.AspNetCore.Mvc.Routing;
using Web.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHttpClient("weather", client => 
{
    // this matches the name of the aspire app reference in the app host
    client.BaseAddress = new Uri("http://api");
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
