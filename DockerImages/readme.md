# Docker Container Images

## Differences

- **[mcr.microsoft.com/dotnet/runtime](https://github.com/dotnet/dotnet-docker/blob/main/README.runtime.md)**: Contains only the .NET runtime and libraries
- **[mcr.microsoft.com/dotnet/aspnet](https://github.com/dotnet/dotnet-docker/blob/main/README.aspnet.md)**: Contains only the ASP.NET runtime and libraries
- **[mcr.microsoft.com/dotnet/runtime-deps](https://github.com/dotnet/dotnet-docker/blob/main/README.runtime-deps.md)**: Designed for **self-contained apps** and does not contain the .NET runtime, but rather dependencies to support it (e.g., ca-certificates, libc6, libgcc, libssl3, libstdc++6, and zlib1g).

## Ubuntu "Chisled" vs Alpine

- Similar base image sizes
    - 8.0.3-jammy-chiseled-amd64 - 13MB
    - 8.0.3-alpine3.19-amd64 - 10MB
- Benefits of Ubuntu Chisled
    - More compatibility with various software packages
    - More supported tooling
- Benefits of Alpine
    - Even smaller size
    - Slightly faster build times
- When to choose:
    - Choose Ubuntu Chiselled when you need a balance between a larger ecosystem, development-friendly features, and reduced image size.
    - Choose Alpine when minimalism, security, and faster build times are critical

## Links
- https://hub.docker.com/_/microsoft-dotnet-runtime/
- https://ubuntu.com/blog/combining-distroless-and-ubuntu-chiselled-containers
- https://hub.docker.com/r/ubuntu/dotnet-deps