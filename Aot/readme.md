# AOT Compilation

Generates a native executable, with optional PDB symbols. The process implements trimming and optimizations to create a single executable that is MUCH smaller than a single/self-contained file. Because the file is native to the OS, the publish operation must target a specific runtime (e.g., `dotnet publish -r win-x64 -c Release`).  

In comparison, the self-contained/single-file publication bundles the .NET runtime components and dependencies inside of the executable, resulting in a much larger file size. AOT-compiled files, are native and optimized for the OS. 

## Support

.NET 7 supports only Console applications, while .NET 8 supports a [subset of ASP.NET functionality](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/native-aot?view=aspnetcore-8.0).

## Size Comparisons

`Console.WriteLine("Hello, World!");`

| Type | Output Size (MB) |
| - | - |
| OT-optimized (size) | 1.3 |
| OT-optimized (speed) | 1.5 |
| PublishSingleFile/SelfContained | 66 |
