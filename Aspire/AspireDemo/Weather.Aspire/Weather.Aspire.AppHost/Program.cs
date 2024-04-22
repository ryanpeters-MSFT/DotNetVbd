var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Api>("api");

builder.AddProject<Projects.Web>("web")
    .WithReference(api);

builder.Build().Run();
