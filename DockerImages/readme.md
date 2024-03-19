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

### Tags

- **Latest (Debian 12 Bookworm)** - 217MB
- **Alpine** - 107MB
- **Ubuntu Jammy (22.04)** - 216MB
-- **Ubuntu Jammy (22.04 slim)** - ??