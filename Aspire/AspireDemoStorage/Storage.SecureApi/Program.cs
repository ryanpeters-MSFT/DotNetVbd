using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// add Aspire connected resources
builder.AddServiceDefaults();
builder.AddAzureBlobService("blobs");
builder.AddAzureKeyVaultSecrets("vault");

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapPost("/upload", async ([FromQuery] string apiKey, HttpRequest request, BlobServiceClient client, SecretClient secrets) =>
{
    var secretResponse = secrets.GetSecret("apikey");

    var value = secretResponse.Value.Value;

    if (value == apiKey)
    {
        var container = client.GetBlobContainerClient("data");
        await container.CreateIfNotExistsAsync();

        var blobName = $"data-{Guid.NewGuid()}";

        using (var reader = new StreamReader(request.Body))
        {
            var content = await reader.ReadToEndAsync();

            await container.UploadBlobAsync(blobName, new BinaryData(content));
        }

        return Results.Ok($"Added content to file: {blobName}");
    }

    return Results.Unauthorized();
});

app.Run();