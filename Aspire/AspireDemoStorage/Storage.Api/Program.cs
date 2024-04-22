using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

// add Aspire connected resources
builder.AddServiceDefaults();
builder.AddAzureKeyVaultSecrets("vault");

// add app-specific services
builder.Services.AddHttpClient();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/", async (SecretClient secrets, IHttpClientFactory httpClientFactory) =>
{
    var secretResponse = secrets.GetSecret("apikey");

    var value = secretResponse.Value.Value;

    var client = httpClientFactory.CreateClient();

    var content = new StringContent("this is a sample payload");

    var uploadResponse = await client.PostAsync($"http://storagesecureapi/upload?apiKey={value}", content);

    if (uploadResponse.IsSuccessStatusCode)
    {
        var response = await uploadResponse.Content.ReadAsStringAsync();

        return Results.Ok($"Api response: {response}");
    }

    return Results.BadRequest();
});

app.Run();