using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.ServiceDiscovery.Abstractions;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config => config.AddJsonFile("appsettings.json"))
    .ConfigureServices(services => 
    {
        services
            .AddHttpClient("recipe", client => client.BaseAddress = new Uri("http://recipe"))
            .UseServiceDiscovery(RandomServiceEndPointSelectorProvider.Instance); // randomly pick an endpoint instead of the (default) round-robin

        services.AddServiceDiscovery();
    });

var host = builder.Build();

var factory = host.Services.GetService<IHttpClientFactory>();

var httpClient = factory.CreateClient("recipe");

var recipe = await httpClient.GetStringAsync("crepes");

Console.WriteLine($"\nCrepe recipe JSON: {recipe}\n");