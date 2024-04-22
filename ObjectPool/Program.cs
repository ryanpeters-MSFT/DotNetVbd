using System.Diagnostics;
using Microsoft.Extensions.ObjectPool;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();

builder.Services.AddSingleton<ObjectPool<ProcessorService>>(serviceProvider =>
{
    var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();

    var policy = new DefaultPooledObjectPolicy<ProcessorService>();

    return provider.Create(policy);
});

var app = builder.Build();

var provider = app.Services.GetService<ObjectPoolProvider>() as DefaultObjectPoolProvider;

app.MapGet("/process", (ObjectPool<ProcessorService> servicePool) =>
{
    var service = servicePool.Get();

    var totalTasksProcessed = service.ProcessJobs();
    var instanceId = service.GetInstanceId();

    servicePool.Return(service);

    return Results.Ok($"Processed {totalTasksProcessed} jobs on instance {instanceId}");
});

app.Start();

var httpClient = new HttpClient();

var totalRequests = 1;

var requests = new List<Task<string>>();

for(var i = 0; i < totalRequests; i++)
{
    var task = httpClient.GetStringAsync("http://localhost:5188/process");

    requests.Add(task);

    Thread.Sleep(1000);
}

await Task.WhenAll(requests);

var results = requests.Select(t => t.Result).ToList();

Console.WriteLine($"\n{totalRequests} responses:\n");

foreach (var result in results)
{
    Console.WriteLine(result);
}

//Console.WriteLine($"\nDistinct IDs: {ids.Distinct().Count()}\n");