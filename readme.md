 # .NET 7/8/9-pre Highlights
- *TBD*

## Loose Notes

### Links:
- https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-7
- https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8/overview
- https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-7.0
- https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-8.0
- https://learn.microsoft.com/en-us/dotnet/core/compatibility/7.0
- https://github.com/dotnet/docs/blob/main/docs/core/whats-new/dotnet-9/overview.md
- https://learn.microsoft.com/en-us/aspnet/core/migration/proper-to-2x/?view=aspnetcore-8.0
- https://learn.microsoft.com/en-us/aspnet/core/migration/60-70?view=aspnetcore-8.0&tabs=visual-studio

## .NET 7 New Features
- Consists mainly performance improvements
- [Enablement of publishing to containers](https://learn.microsoft.com/en-us/dotnet/core/docker/publish-as-container) ([Examples](./DockerPublish/))
- [Regex improvements](https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-source-generators)
- [Math interfaces](https://learn.microsoft.com/en-us/dotnet/standard/generics/math) ([Examples](./MathInterfaces/))
- Nanoseconds in datetime
- Relection improvements
- App trimming is [now enabled by default for console apps](https://learn.microsoft.com/en-us/dotnet/core/compatibility/deployment/7.0/trim-all-assemblies)
- Memory caching improvements
- Improvements to opentelemetry
- .PatchAsync() and .PatchAsJsonAsync()

## ASP.NET 7
- [API Rate Limiting](https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?preserve-view=true&view=aspnetcore-7.0) ([Examples](./RateLimiting/))
- No longer need to explicitly use [FromServices] - can now infer from services implicitly
- [Minimal API filters](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/min-api-filters)
- Binding query string values from arrays using primitive types
- Improvements to Results.Stream (to access underlying HTTP response stream)

## .NET 8 New Features
- Even more performance improvements
- AOT improvements (?) - reduced memory footprint, improved startup time, better efficiencyt (100mb reduced to 10mb, e.g.)
- SHA-3 support
- GC improvements
- serialization improvments (JSON)
- Hot reload improvements
- Simplified list ordering  using `.Order()` and `.OrderDescending()` for sortable types (replaces `.OrderBy(x => x)`)
- `required` keyword for properties ([Example](./RequiredAttributes/Person.cs))
- [Frozen list types](https://learn.microsoft.com/en-us/dotnet/api/system.collections.frozen.frozenset-1) ([Example](./FrozenSets/Program.cs))
- Keyed dependencies/services
- primary constructors
- collection expressions - shorthand for defining collections, such as arrays and list (also see spread element)
- `[Experimental]` attribute
- EF improvements (DateOnly and TimeOnly)
- .NET Aspire - https://www.youtube.com/watch?v=DORZA_S7f9w

## AOT (.NET 7 and .NET 8)
- "Ahead of time" compilation
- Generates a single, self-contained, OS-specific executable to create a native binary
- The result is faster startup times and smaller footprint, and no framework is needed
- When compared to "single file", which includes all framework-supporting code within it, is usually MUCH larger than a AOT deployment. This is because the former is still leveraging the .NET runtime (encapsulated inside a single executable), whereas the AOT binary is OS-native.
- No JIT - all optimizations are created "ahead of time"
- The AOT optimization process can be based on "speed" or "size", instead of the default "blended" approach
- Trimming is used, but [additional settings can be set](https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/trimming-options?pivots=dotnet-8-0)
- Debugging options:
    - PDB symbols can be produced
    - managed debuggers won't work, but the OS-native debugger can
- P/invoke calls are lazy-loaded by default for better compatibility


## ASPIRE

[Overview](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)

- **Cloud-Ready Stack**: .NET Aspire is an opinionated, cloud-ready stack for building observable, production-ready, distributed applications. It's designed to improve the experience of building .NET cloud-native apps.
- **Orchestration**: .NET Aspire provides features for running and connecting multi-project applications and their dependencies for local development environments. It simplifies the management of your cloud-native app’s configuration and interconnections.
- **Components**: .NET Aspire components are NuGet packages for commonly used services, such as Redis or Postgres, with standardized interfaces ensuring they connect consistently and seamlessly with your app.
- **Tooling**: .NET Aspire comes with project templates and tooling experiences for Visual Studio and the dotnet CLI to help you create and interact with .NET Aspire apps.
- **Resilience, Service Discovery, Telemetry, and Health Checks**: .NET Aspire includes a curated set of components enhanced for cloud-native by including service discovery, telemetry, resilience, and health checks by default.

The problem .NET Aspire is trying to solve is the complexity of building cloud-native apps. Developers are often pulled away from their business logic to deal with the complexity of the cloud. .NET Aspire aims to simplify this complexity, making it easier for developers to build and manage cloud-native applications.

***TODO***
- include link to repo and demo apps
- move this readme to app

## Docker
- **Support for Chiseled Containers**: .NET 8 has started shipping Docker images built directly on chiseled containers. These are stripped-down versions of Ubuntu, where only the essential packages for running your application are included. This results in smaller images and a reduced attack surface.
- **Smaller Images and Improved R2R with Composite Images**: The images have been optimized to be smaller and more efficient.
- **Running Container Images with Non-Root Users**: The new non-root capability of the Microsoft .NET containers is now the default, which helps your apps stay secure-by-default.
- **ASP.NET Core Apps Now Use Port 8080 by Default**: The default port has been changed from port 80 to 8080.
- **Dependency Changes in Alpine .NET 8 Images**: There have been some changes in the dependencies in the Alpine .NET 8 images.
- **Debian 12 Images**: The container images now use Debian 12 (Bookworm) when targeting the "latest" tag for the runtime. Debian is the default Linux distro in the .NET container images.
- **Build Multi-Platform Container Images**: .NET 8 introduces a new pattern that enables you to mix and match architectures with the .NET images you build.

### Links
- [List of supported runtime tags](https://hub.docker.com/_/microsoft-dotnet-runtime/)