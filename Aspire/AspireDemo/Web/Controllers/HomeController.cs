using Microsoft.AspNetCore.Mvc;
using Common;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient httpClient;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        this.httpClient = httpClientFactory.CreateClient("weather");
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Forecasts = await httpClient.GetFromJsonAsync<ICollection<WeatherForecast>>("forecast");

        return View();
    }
}
