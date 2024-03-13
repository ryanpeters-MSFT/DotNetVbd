# `required` Modifier (.NET 7, C# 11)

If a `required` property is set on a class, that property must have a value set at the time of initialization. Even if a default value is set on the property (in the class), it will fail, as the initialization step requires it. 

*This is not to be confused with the `[Required]` attribute used for validation purposes*

### Example
- [Person.cs](./Person.cs)
- [Program.cs](./Program.cs)

# `[Experimental]` Attribute (.NET 8, C# 12)

When set on a type, method, enum, etc, indicates that the functionality is experimental and may change in the future. 

In order to use the feature, you must wrap the invocation in `#pragma` flags to disable the warning. 

### Example
- [Program.cs](./Program.cs)