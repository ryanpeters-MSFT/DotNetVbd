# Various Web API Feature Examples

## Minimal API Filters

In ASP.NET Core 7, Minimal APIs introduce a lightweight way to create REST API endpoints without the need for traditional controllers. As part of request and response chaining, filters can be added to the pipeline to apply filtering or modification of request parameters. Also, similar to middleware pipeline chaining, the output/response of an action can be modified or filtered before being sent to the client. 

There are two primary ways to add filters to a minimal API endpoint:

### Use `.AddEndpointFilter(...)` Extension

asdsa

### Implemenent `IEndpointFilter`