# `FrozenSet<T>()` (.NET 8, C# 11)

`FrozenSet` is a feature introduced in .NET 8. It serves as an immutable counterpart to the traditional `Set` types, such as `HashedSet<T>` and `SortedSet<T>`. Unlike a regular set which is mutable, a `FrozenSet` has its contents forever fixed and unmodifiable.

Similar to a read-only collection (e.g., `ReadOnlyColletion<T>`), provides additional performance optimizations for collections that never need to change. It is similar to a `ImmutableList<T>`, but cannot be mutated once frozen (immutable lists can get around this by creating a new list, e.g., using `.Add()`). Once a list is "frozen", changes are no longer reflected. Adding an item to the list will reflect no changes.

## Benefits of using FrozenSet

- **Stability and Predictability**: `FrozenSet` ensures that your collection of items remains constant throughout the lifecycle of your application.
- **Data Consistency**: This is particularly useful in multi-threaded applications where data consistency is important.
- **Performance**: `FrozenSet` is optimized for situations where a set is created infrequently but is used frequently at run time. It has a relatively high cost to create but provides excellent lookup performance.

In conclusion, `FrozenSet` in .NET provides a way to handle collections that need to remain constant, offering benefits in terms of stability, data consistency, and performance.

## Links

- [Benchmarks](https://steven-giesel.com/blogPost/34e0fd95-0b3f-40f2-ba2a-36d1d4eb5601)
- [`FrozenSet<T>` Class](https://learn.microsoft.com/en-us/dotnet/api/system.collections.frozen.frozenset-1?view=net-8.0)