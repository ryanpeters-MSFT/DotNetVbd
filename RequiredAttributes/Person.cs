using System.Diagnostics.CodeAnalysis;

public class Person
{
    // this field is required to have a value at compilation time
    public required string Name { get; set; }

    [Experimental("SomethingNew")]
    public void SomethingNew()
    {
        Console.WriteLine("This is a new experimental feature");
    }
}