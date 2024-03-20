# Docker Container Images

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
- https://ubuntu.com/blog/combining-distroless-and-ubuntu-chiselled-containers