var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/crepes", () =>
{
    var recipe = new Recipe("Crepes", ["2 Eggs (beaten)", "1 CUP Milk", "1 CUP Flour", "2 TBSP Butter", "1/4 TSP salt"]);

    return Results.Ok(recipe);
});

app.Run();

record Recipe(string Name, string[] Ingredients);