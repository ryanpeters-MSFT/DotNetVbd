using System.Diagnostics.CodeAnalysis;

public class Person
{
    // this field is required to have a value at compilation time, even if a default value is set
    public required string Name { get; set; } = "this will NOT work!";

    [Experimental("SomethingNew")]
    public void SomethingNew()
    {
        Console.WriteLine("This is a new experimental feature");
    }
}