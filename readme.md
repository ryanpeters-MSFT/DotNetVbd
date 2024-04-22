 # .NET 7 and .NET 8 New Features

.NET 7 and .NET 8 represent the next yearly releases after .NET 6. .NET 6 was released on November 2021 and was an LTS release, meaning it had a 3-year support window. The releases of .NET 7 and .NET 8 represent STS and LTS releases, respectively, meaning that .NET 8 also carries with it a 3-year support window, ending in November of 2026.

![.NET release cycle](./.images/release-schedule-dark.svg)

### .NET 7 Highlights:
1. **Performance Boosts**: .NET 7 introduces enhancements across the board. The runtime now boasts improved performance, garbage collection efficiency, and optimizations in core and extension libraries.
2. **Globalization Mode for Mobile Apps**: A new globalization mode caters specifically to mobile applications, ensuring smoother internationalization and localization.
3. **Source Generators**: .NET 7 introduces source generators for COM interop and configuration binding, streamlining code generation and improving developer productivity.

### .NET 8 Highlights:
1. **Long-Term Support (LTS)**: .NET 8 continues the tradition of LTS releases, promising three years of support. It's a reliable choice for long-lived applications.
2. **C# 12**: Shipped alongside .NET 8, C# 12 brings language enhancements and features that enhance expressiveness and readability in your codebase.
3. **Security and Hardware Support**: .NET 8 introduced support for the SHA-3 hash algorithms, including SHAKE-128 and SHAKE-256. SHA-3 support is currently supported on Windows 11 build 25324 or later, and Linux with OpenSSL 1.1.1 or later.
4. **.NET Aspire**: This opinionated, cloud-ready stack simplifies building observable, production-ready, distributed applications. It's available in preview for .NET 8.
5. **ASP.NET Core 8.0 Enhancements**:
    - **Blazor**: Improvements in Blazor, SignalR, and minimal APIs enhance web development.
    - **Native AOT**: ASP.NET Core now supports Native Ahead-of-Time (AOT) compilation.
    - **Authentication and Authorization**: Enhanced features for secure user authentication and authorization.
6. **EF Core 8**: Entity Framework Core gains improvements in complex type objects, JSON column mapping, raw SQL queries, and more. Plus, a new HierarchyId type is introduced.
7. **Windows Forms and WPF**: Both Windows Forms and Windows Presentation Foundation (WPF) receive updates, including better data binding, high DPI support, and hardware acceleration for WPF.

## Links:

- **What's New**
    - [.NET 7](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-7)
    - [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8/overview)
    - [ASP.NET 7](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-7.0)
    - [ASP.NET 8](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-8.0)
    - [.NET 9 (Preview)](https://github.com/dotnet/docs/blob/main/docs/core/whats-new/dotnet-9/overview.md)
- **Breaking Changes**
    - [.NET 7](https://learn.microsoft.com/en-us/dotnet/core/compatibility/7.0)
    - [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/compatibility/8.0)
- **Upgrading and Migrating**
    - [Upgrade from ASP.NET Framework to ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/migration/proper-to-2x/)
    - [Migrate from ASP.NET Core 6.0 to 7.0](https://learn.microsoft.com/en-us/aspnet/core/migration/60-70)

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
- [No longer need to explicitly use [FromServices]](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-7-preview-2/) ([Examples](./WebApi/Controllers/ClientController.cs))
- [Minimal API filters](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/min-api-filters) ([Examples](./WebApi/EndpointFilters/EvenNumberFilter.cs))
- [IParsable model binding](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-7.0) ([Example](./WebApi/Models/Vin.cs))
- Binding query string values from arrays using primitive types
- Improvements to Results.Stream (to access underlying HTTP response stream)

## .NET 8 New Features
- Even more performance improvements
- [Service Discovery](https://learn.microsoft.com/en-us/dotnet/core/extensions/service-discovery) ([Examples](./ServiceDiscovery/))
- AOT improvements - reduced memory footprint, improved startup time, better efficiencyt (100mb reduced to 10mb, e.g.)
- SHA-3 support
- [Object pooling support](https://learn.microsoft.com/en-us/aspnet/core/performance/objectpool) ([Example](./ObjectPool/))
- GC improvements
- Serialization improvments (JSON)
- Hot reload improvements
- Simplified list ordering  using `.Order()` and `.OrderDescending()` for sortable types (replaces `.OrderBy(x => x)`)
- `required` keyword for properties ([Example](./RequiredAttributes/Person.cs))
- [Frozen list types](https://learn.microsoft.com/en-us/dotnet/api/system.collections.frozen.frozenset-1) ([Example](./FrozenSets/))
- Keyed DI/services ([Example](./WebApi/Controllers/AccountController.cs))
- Primary constructors ([Example](./RateLimiting/Client.cs))
- collection expressions - shorthand for defining collections, such as arrays and list (also see spread element)
- `[Experimental]` attribute ([Example](./RequiredAttributes/Person.cs))
- EF improvements (DateOnly and TimeOnly)
- .NET Aspire - https://www.youtube.com/watch?v=DORZA_S7f9w

## AOT (.NET 7 and .NET 8)

- [Examples](./Aot/)
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





***TODO***
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
- [Performance Improvements in .NET 8](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-8/)
- [List of supported runtime tags](https://hub.docker.com/_/microsoft-dotnet-runtime/)
- [5 new MVC features in .NET 7](https://andrewlock.net/5-new-mvc-features-in-dotnet-7/)