# AOT Compilation

Generates a native executable, with optional PDB symbols. The process implements trimming and optimizations to create a single executable that is MUCH smaller than a single/self-contained file. Because the file is native to the OS, the publish operation must target a specific runtime (e.g., `dotnet publish -r win-x64 -c Release`).  

In comparison, the self-contained/single-file publication bundles the .NET runtime components and dependencies inside of the executable, resulting in a much larger file size. AOT-compiled files, are native and optimized for the OS. 

## Benefits of AOT

- **Faster startup time** - Since there's no Just-In-Time (JIT) compilation overhead during runtime, the application launches more quickly.
- **Smaller memory footprint** - The compiled native code is more compact than IL, leading to reduced memory usage.
- **Runtime independence** - Native AOT apps can run on machines without the .NET runtime installed.

## How AOT Works

Ahead-of-Time (AOT) compilation in .NET 7+ is a technique where code is compiled into **native machine code** before the application runs, rather than during runtime. 

During the publishing phase, the AOT compiler processes the Intermediate Language (IL) code and generates native machine code directly from it. Unlike Just-In-Time (JIT) compilation, which occurs at runtime, AOT eliminates the need for JIT overhead during execution. The resulting application is self-contained, meaning it includes all necessary dependencies and doesn't rely on the presence of the .NET runtime on the target machine. AOT offers benefits such as faster startup times, smaller memory footprint, and runtime independence. However, it has limitations related to compatibility with certain libraries and is most suitable for scenarios with many deployed instances.

## Key Points

- The result is faster startup times and smaller footprint, and no framework is needed
- When compared to "single file", which includes all framework-supporting code within it, is usually MUCH larger than a AOT deployment. This is because the former is still leveraging the .NET runtime (encapsulated inside a single executable), whereas the AOT binary is OS-native.
- No JIT - all optimizations are created "ahead of time"
- The AOT optimization process can be based on "speed" or "size", instead of the default "blended" approach
- Trimming is used, but [additional settings can be set](https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/trimming-options?pivots=dotnet-8-0)
- Debugging options:
    - PDB symbols can be produced
    - managed debuggers won't work, but the OS-native debugger can
- P/invoke calls are lazy-loaded by default for better compatibility
## Support

.NET 7 supports only Console applications, while .NET 8 supports a [subset of ASP.NET functionality](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/native-aot?view=aspnetcore-8.0).

## Size Comparisons

```csharp
Console.WriteLine("Hello, World!");
```

| Type | Output Size (MB) |
| - | - |
| OT-optimized (size) | 1.3 |
| OT-optimized (speed) | 1.5 |
| PublishSingleFile/SelfContained | 66 |
