# Service Discovery (.NET 8, Preview)

Service Discovery ([currently in preview for .NET 8 and 9](https://www.nuget.org/packages/Microsoft.Extensions.ServiceDiscovery)) allows for referencing of HTTP service endpoints by name instead of by IP address and port. 

The service also supports invoking a series of endpoints, using multiple built-in providers:

| Provider | Description |
| - | - |
| RoundRobinServiceEndPointSelector | Selects endpoints by iterating through the list of endpoints in a round-robin fashion. *This is the default option.* |
| RandomServiceEndPointSelector | A service endpoint selector which returns random endpoints from the collection. |
| PickFirstServiceEndPointSelector | A service endpoint selector which always returns the first endpoint in a collection. |
| PowerOfTwoChoicesServiceEndPointSelector | Selects endpoints using the Power of Two Choices algorithm for distributed load balancing based on the last-known load of the candidate endpoints. |

When deployed into a cloud environment that supports native service disovery (such as Azure App Service or Kubernetes), as pass-through mode is utilized, allowing for developer-specific endpoint configuration to not affect the service connectivity in production/cloud environments. 

## Links

- [Service Discovery in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/service-discovery)