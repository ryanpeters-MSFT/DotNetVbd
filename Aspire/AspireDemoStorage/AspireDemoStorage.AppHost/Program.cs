var builder = DistributedApplication.CreateBuilder(args);

// configure storage container blob resource
var blobs = builder.AddAzureStorage("storage").AddBlobs("blobs");

// configure AKV resource
var vault = builder.AddAzureKeyVault("vault");

var secureApi = builder.AddProject<Projects.Storage_SecureApi>("storagesecureapi")
    .WithReference(vault)
    .WithReference(blobs);

builder.AddProject<Projects.Storage_Api>("storageapi")
    .WithReference(vault)
    .WithReference(secureApi);

builder.Build().Run();
