# IParsable<T>

The `IParsable<TSelf>` interface in .NET 7.0 is designed to solve the problem of parsing a string into a value of a specific type. This interface defines a mechanism for parsing a string to a value. It includes two static abstract methods: `Parse(string s, IFormatProvider? provider)` and `TryParse(string? s, IFormatProvider? provider, out TSelf result)`.

This interface opens up a new range of syntax possibilities, including generic parsing. In this example, we see various ways to leverage the same functionality and extension to be able to parse any type from a given string. In addition, this example shows how you can have a generic extension method that parses a string to anything. 

In .NET 7.0, `IParsable<T>` is implemented by all numeric types like `int`, `byte`, `double`, and other types usually subject to parsing like `DateTime`, `DateOnly` or `Guid`.

### Links

- [The new .NET 7.0 IParsable<TSelf> interface](https://blog.ndepend.com/the-new-net-7-0-iparsable-interface/)