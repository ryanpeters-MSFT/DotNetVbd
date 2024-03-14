using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRateLimiter(_ =>
{
    _.AddFixedWindowLimiter("fixed-limiter", options =>
    {
        options.PermitLimit = 3;
        options.Window = TimeSpan.FromSeconds(10);
        options.QueueLimit = 3;
        options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
    });

    _.AddSlidingWindowLimiter("sliding-limiter", options =>
    {
        options.PermitLimit = 3;
        options.SegmentsPerWindow = 3;
        options.QueueLimit = 3;
        options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
    });

    _.AddConcurrencyLimiter("concurrent-limiter", options =>
    {
        options.PermitLimit = 3;
        options.QueueLimit = 3;
    })
});

var app = builder.Build();

int fixedRequests = 0, slidingRequests = 0;

app.MapGet("/fixed", () => Results.Ok(++fixedRequests)).RequireRateLimiting("fixed-limiter");

app.MapGet("/sliding", () => Results.Ok(++slidingRequests)).RequireRateLimiting("sliding-limiter");

var options = new RateLimiterOptions
{
    GlobalLimiter = PartitionedRateLimiter.Create(),
    RejectionStatusCode = 429 // rate limited
}

app.UseRateLimiter(options);

app.Run();