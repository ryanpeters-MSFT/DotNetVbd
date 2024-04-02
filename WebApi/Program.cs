using EndpointFilters;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/addsmallnumbers", (int x, int y) =>
{
    return Results.Ok(x + y);

}).AddEndpointFilter(async (ctx, next) => 
{
    var x = ctx.GetArgument<int>(0);
    var y = ctx.GetArgument<int>(1);

    if (x > 10 || y > 10)
    {
        return Results.BadRequest("One of your numbers is too big!");
    }    

    var result = await next(ctx);

    if (result is Ok<int> okResult && okResult.Value > 15) 
    {
        return Results.BadRequest("Even the result is too big!");
    }

    return result;

}).AddEndpointFilter<EvenNumberFilter>();

app.Run();