using System.Diagnostics.CodeAnalysis;

int stringToNumber = "1".Parse<int>();
decimal stringToDecimal = "45.3".Parse<decimal>();
Person nameToPerson = "Ryan|40|Microsoft".Parse<Person>();

Console.WriteLine(stringToNumber);
Console.WriteLine(stringToDecimal);
Console.WriteLine($"{nameToPerson.Name}, age {nameToPerson.Age}, works for {nameToPerson.Employer}");

static class Extensions
{
    internal static T Parse<T>(this string text) where T : IParsable<T> => T.Parse(text, null);
}

class Person : IParsable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Employer { get; set; }

    public static Person Parse(string s, IFormatProvider? provider)
    {
        if (TryParse(s, provider, out var person))
        {
            return person;
        }

        throw new ArgumentException("Name is empty", nameof(s));
    }

    public static bool TryParse([NotNullWhen(true)] string? data, IFormatProvider? provider, [MaybeNullWhen(false)] out Person result)
    {
        var split = data.Split('|');

        result = new Person
        {
            Name = split[0],
            Age = int.Parse(split[1]),
            Employer = split[2]
        };

        return true;
    }
}