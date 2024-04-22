# Publish Container Image using `dotnet publish` (.NET 7)

Publishing a Docker image from a .NET application in .NET 7 is streamlined with the `dotnet publish` command. This process eliminates the need for a Dockerfile and allows developers to containerize their .NET applications directly. If you are running .NET 7 SDK, you must include the `Microsoft.NET.Build.Containers` NuGet package to your project. As of .NET 8, these package APIs are part of the core SDK. Once added, you can configure the Docker image properties within the `.csproj` file, such as setting the image name and tag using the `ContainerImageName` and `ContainerImageTag` properties. Finally, you publish the image to your local Docker daemon with the `dotnet publish` command, specifying the target OS and architecture. This command builds the application and packages it into a Docker image, ready for deployment.

- Does not require `Dockerfile`
- Not all project templates work (e.g., Console)