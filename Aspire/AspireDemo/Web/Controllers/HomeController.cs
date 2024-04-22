using Microsoft.AspNetCore.Mvc;
using Common;

namespace Web.Controllers;

public class HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger) : Controller
{
    private readonly HttpClient httpClient = httpClientFactory.CreateClient("weather");
    private readonly ILogger<HomeController> logger = logger;

    public async Task<IActionResult> Index()
    {
        var forecasts = await httpClient.GetFromJsonAsync<ICollection<WeatherForecast>>("forecast");

        Console.WriteLine($"Retrieved {forecasts.Count} forecasts");
        logger.LogInformation($"Retrieved {forecasts.Count} forecasts");

        ViewBag.Forecasts = forecasts;

        return View();
    }
}
