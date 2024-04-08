# Various Web API Feature Examples

This project highlights various ASP.NET-related features.

## Minimal API Filters

In ASP.NET Core 7, Minimal APIs introduce a lightweight way to create REST API endpoints without the need for traditional controllers. As part of request and response chaining, filters can be added to the pipeline to apply filtering or modification of request parameters. Also, similar to middleware pipeline chaining, the output/response of an action can be modified or filtered before being sent to the client. 

There are two primary ways to add filters to a minimal API endpoint:

### Use `.AddEndpointFilter(...)` Extension

When this extension is chained to a `.MapXxx(...)` endpoint, it provides a delegate to configure filtering to execute both before AND after the call is made. In this example, the */addsmallnumbers* endpoint has a check to see if the numbers are BOTH less than 10, and if so, returns a 400 BadRequest. In addition, AFTER the action is executed (by way of invoking `await next(ctx);`), if the resulting addition is greater than 15, it will (again) throw a 400 BadRequest error. 

### Implemement `IEndpointFilter`

When endpoint filters are implemented by the `IEndpointFilter` interface, they support the same functionality and provide the same mechanism for handling filtering both before and after the request. However, since this is using a class, you can take advantage of things such as dependency injection to further enhance functionality within the filter. 

## Implicit DI Service Resolution in Methods

This feature allows for the instances of registered services to be resolved without having to specify `[FromServices]`. Previously, to include a service dependency from `IServiceProvider` from within a method, you would need to include the `[FromServices]` attribute, such as:

```csharp
public IActionResult GetClient(int id, [FromServices] IClientRepository clientRepository) { }
```

If this feature needs to be disabled, it can be done so explicitly:

```csharp
builder.Services.Configure<ApiBehaviorOptions>(options => 
{
    options.DisableImplicitFromServicesParameters = true;
});
```

## Keyed Service Registration

This feature allows for the specification of services using a string label and then explicitly request the exact instance in the code. 

For example, you can regsiter the services using the new `.AddKeyedTransient("service-name")` extension method (and similarly for `.AddKeyedScoped()` and `.AddKeyedSingleton()`) and then request it using a new `[FromKeyedServices("service-name")]` attribute. 

```csharp
builder.Services.AddKeyedSingleton<IRepository, FirstRepository>("first");
builder.Services.AddKeyedSingleton<IRepository, SecondRepository>("second");
```

To request a type explicitly, you can use `[FromKeyedServices("second")]` in your code to get an instance of `SecondRepository`:

```csharp
public class MyLibrary([FromKeyedServices("second")] IRepository repository) 
{ 
    // ...
}
```

In versions prior to .NET 8, if multiple implementations of a service are registered, the only way to handle retrieving a specific version would be to include the services as a collection and iterate/filter based on name/metadata/etc to determine the correct one to use. 

For example, suppose my application registered the following:

```csharp
builder.Services.AddSingleton<IRepository, FirstRepository>();
builder.Services.AddSingleton<IRepository, SecondRepository>();
```

If multiple implementations of the type are defined, by default, if I ask for an instance of type `IRepository`, I would receive an instance of the last type registered against `IServiceCollection`. Meaning, I would get an instance of `SecondRepository` because it was the last one registered. 

Another approach is to ask for ALL instances, by requesting an instance of `IEnumerable<IRepository>` and iterate through the collection to find the instance needed. 

## Model Binding with `IParsable<T>.TryParse`

Leveraging the new `IParsable<T>` interface, in addition to providing constructs to parse between different types, can be used as part of the model binder to create a model type from a string, ultimately invoking the `IParsable<T>.TryParse` static method. 

In this example, a `VinController` is exposes a single `Parse` endpoint that accepts a VIN as a string and returns a JSON result with the parsed segments. Because the `Vin` type implements `IParsable<Vin>`, and thus handles all of the parsing to create the `Vin` object, the controller endpoint has no actual parsing logic, and instead returns the (parsed) `Vin` request object as the result. 

### Links
- [.NET 7.0 IParsable<TSelf> interface](https://blog.ndepend.com/the-new-net-7-0-iparsable-interface/)