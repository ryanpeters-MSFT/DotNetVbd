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

### .NET 7 NEW FEATURES
- mainly performance improvements
- AOT
- .PatchAsync() and .PatchAsJsonAsync()
- regex improvements - https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-source-generators
- math interfaces - https://learn.microsoft.com/en-us/dotnet/standard/generics/math
- nanoseconds in datetime
- relection improvements (?)
- app trimming - now enabled by default for console apps - https://learn.microsoft.com/en-us/dotnet/core/compatibility/deployment/7.0/trim-all-assemblies
- memory caching improvements (?)
- new improvements to opentelemetry
- enablement of publishing to containers - https://learn.microsoft.com/en-us/dotnet/core/docker/publish-as-container?pivots=dotnet-8-0

### ASP.NET 7
- rate limiting - https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?preserve-view=true&view=aspnetcore-7.0
- no longer need to explicitly use [FromServices], can now infer from services implicitly
- minimal api filters
- binding query string values from arrays using primitive types
- improvements to Results.Stream (to access underlying HTTP response stream)

### .NET 8 NEW FEATURES
- more performance improvements
- AOT improvements (?) - reduced memory footprint, improved startup time, better efficiencyt (100mb reduced to 10mb, e.g.)
- SHA-3 support
- GC improvements
- serialization improvments (JSON)
- Hot reload improvements
- Simplified Ordering (.Order(), .OrderDescending())
- `required` keyword for properties
- [Frozen list types](https://learn.microsoft.com/en-us/dotnet/api/system.collections.frozen.frozenset-1)
- keyed dependencies/services
- primary constructors
- collection expressions - shorthand for defining collections, such as arrays and list (also see spread element)
- `[Experimental]` attribute
- EF improvements (DateOnly and TimeOnly)
- .NET Aspire - https://www.youtube.com/watch?v=DORZA_S7f9w

### AOT 
- generates a single, self-contained, OS-specific executable
- creates a native binary
- result is faster startup times and smaller footprint, and no framework is needed
- no JIT
- true
- can my optimized based on "speed" or "size", instead of the default "blended" approach
- trimming is used, but additional settings can be set: https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/trimming-options?pivots=dotnet-8-0
- debugging:
    - PDB symbols can be produced
    - managed debuggers won't work, but the OS-native debugger can
- P/invoke calls are lazy-loaded by default for better compatibility
- compared to "single file", which includes all framework-supporting code within it, is usually MUCH larger than a AOT deployment

### ASPIRE
- commands:

  dotnet workload update
  dotnet workload install aspire

### Docker
- containers no longer ran as root by default
- chisled docker images
- default port is now 8080