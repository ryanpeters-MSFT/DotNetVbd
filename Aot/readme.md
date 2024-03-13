# AOT Compilation

Generates a native executable, with optional PDB symboles. The process implements trimming and optimizations to create a single executable that is MUCH smaller than a single/self-contained file. Because the file is native to the OS, the publish operation must target a specific runtime (e.g., `dotnet publish -r win-x64 -c Release`).  

### Size Comparisons

`Console.WriteLine("Hello, World!");`

| Type | Size (MB) |
| - | - |
| OT-optimized (size) | 1.3 |
| OT-optimized (speed) | 1.5 |
| PublishSingleFile/SelfContained | 66 |
