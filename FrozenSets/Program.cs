using System.Collections.Frozen;
using System.Collections.Immutable;

// define a regular list
var items = new List<int> { 1, 2, 3 };

// create readonly and frozen sets
var readonlyItems = items.AsReadOnly();
var frozenItems = items.ToFrozenSet();
var immutableItems = items.ToImmutableList();

// add 2 items
items.Add(3);
items.Add(4);

// create a new list from the immutable list, with a 4th item
var newList = immutableItems.Add(4);

Console.WriteLine($"{nameof(items)} count: {items.Count}");
Console.WriteLine($"{nameof(readonlyItems)} count: {readonlyItems.Count}");
Console.WriteLine($"{nameof(frozenItems)} count: {frozenItems.Count}");
Console.WriteLine($"{nameof(immutableItems)} count: {immutableItems.Count}");
Console.WriteLine($"{nameof(newList)} count: {newList.Count}");