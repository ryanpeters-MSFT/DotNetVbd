# Generic Math

Although previewed in .NET 6, .NET 7 adds full support for being able to define type constraints for number "types", similar to a constraint is used for a reference type or a struct. 

For example, in the method below, it can be invoked with any type for `T`, such as Int32, Int64, Float, Double, Decimal, etc. Previously, one would have to either create overloads for each type of `T` or apply tricky conversion using reflection to sum the values. 

```csharp
static T Add<T>(T left, T right) where T : INumber<T>
{
    return left + right;
}
```

## Links

- [.NET 7 Preview 5 – Generic Math](https://devblogs.microsoft.com/dotnet/dotnet-7-generic-math/)
- [Generic Math](https://learn.microsoft.com/en-us/dotnet/standard/generics/math)