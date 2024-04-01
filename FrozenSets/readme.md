# `FrozenSet<T>()` (.NET 8, C# 11)

Similar to a read-only collection (e.g., `ReadOnlyColletion<T>`), provides additional performance optimizations for collections that never need to change. It is similar to a `ImmutableList<T>`, but cannot be mutated once frozen (immutable lists can get around this by creating a new list, e.g., using `.Add()`). 

Once a list is "frozen", changes are no longer reflected. Adding an item to the list will reflect no changes.

## Links

- [Benchmarks](https://steven-giesel.com/blogPost/34e0fd95-0b3f-40f2-ba2a-36d1d4eb5601)