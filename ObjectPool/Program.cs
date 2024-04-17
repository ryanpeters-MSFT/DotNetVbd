using System.Diagnostics;
using Microsoft.Extensions.ObjectPool;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ObjectPoolProvider>(services => 
{
    return new DefaultObjectPoolProvider
    {
        //MaximumRetained = 5 // default is 16
    };
});

builder.Services.AddSingleton<ObjectPool<Service>>(serviceProvider =>
{
    var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();

    var policy = new DefaultPooledObjectPolicy<Service>();

    return provider.Create(policy);
});

var app = builder.Build();

var provider = app.Services.GetService<ObjectPoolProvider>() as DefaultObjectPoolProvider;

app.MapGet("/instance", (ObjectPool<Service> servicePool) =>
{
    var stopwatch = new Stopwatch();

    stopwatch.Start();

    var service = servicePool.Get();

    stopwatch.Stop();

    var id = service.GetInstanceId();

    Console.WriteLine($"RETRIEVED instance => \tTime: {stopwatch.ElapsedMilliseconds}ms\tID: {id}");

    servicePool.Return(service);

    return Results.Ok(id);
});

app.Start();

var httpClient = new HttpClient();

var totalRequests = 10;

var requests = new List<Task<string>>();

for(var i = 0; i < totalRequests; i++)
{
    var task = httpClient.GetStringAsync("http://localhost:5188/instance");

    requests.Add(task);

    Thread.Sleep(1000);
}

await Task.WhenAll(requests);

var ids = requests.Select(t => Guid.Parse(t.Result.Trim('"'))).ToList();

Console.WriteLine($"\n{totalRequests} responses:\n");

foreach (var id in ids)
{
    Console.WriteLine(id);
}

Console.WriteLine($"\nDistinct IDs: {ids.Distinct().Count()}\n");