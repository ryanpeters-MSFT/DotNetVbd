using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// add test client
builder.Services.AddTransient<Client>();
builder.Services.AddHttpClient<Client>();

builder.Services.AddRateLimiter(_ =>
{
    _.AddFixedWindowLimiter("fixed-limiter", options =>
    {
        options.PermitLimit = 3;
        options.Window = TimeSpan.FromSeconds(5);
        options.QueueLimit = 2;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });

    _.AddSlidingWindowLimiter("sliding-limiter", options =>
    {
        options.PermitLimit = 3;
        options.SegmentsPerWindow = 2;
        options.QueueLimit = 2;
        options.Window = TimeSpan.FromSeconds(5);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });

    _.AddConcurrencyLimiter("concurrent-limiter", options =>
    {
        options.PermitLimit = 3;
        options.QueueLimit = 2;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});

var app = builder.Build();

app.MapGet("/fixed/{id}", (int id) => Results.Ok(id)).RequireRateLimiting("fixed-limiter");

app.MapGet("/sliding/{id}", (int id) => Results.Ok(id)).RequireRateLimiting("sliding-limiter");

app.MapGet("/concurrent/{id}", (int id) =>
{
    Thread.Sleep(2000);

    return Results.Ok(id);
}).RequireRateLimiting("concurrent-limiter");

app.UseRateLimiter();
app.Start();

var url = app.Urls.First();

Thread.Sleep(3000);

var client = app.Services.GetService<Client>();

await client.ConcurrentTestAsync(url, "fixed", 10);
//await client.ConcurrentTestAsync(url, "sliding", 10);
//await client.ConcurrentTestAsync(url, "concurrent", 10);