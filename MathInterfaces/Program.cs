using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        var numbers = new[] { 1, 2, 3, 4, 247 };
        var decimals = new[] { 1.9m, 3.6m, 5.3m };

        var sum1 = Sum(numbers);
        var sum2 = Sum<int, byte>(numbers);
        var sum3 = Sum(decimals);
        var sum4 = Sum<decimal, int>(decimals);
        

        Console.WriteLine("\nSumming array of ints");
        Console.WriteLine(sum1);
        Console.WriteLine(sum1.GetType().Name);

        Console.WriteLine("\nSumming array of ints and as a byte");
        Console.WriteLine(sum2);
        Console.WriteLine(sum2.GetType().Name);

        Console.WriteLine("\nSumming array of decimals");
        Console.WriteLine(sum3);
        Console.WriteLine(sum3.GetType().Name);
        
        Console.WriteLine("\nSumming array of decimals and as a int");
        Console.WriteLine(sum4);
        Console.WriteLine(sum4.GetType().Name);
    }

    public static TResult Sum<T, TResult>(IEnumerable<T> values) where T : INumber<T> where TResult : INumber<TResult>
    {
        TResult result = TResult.Zero;

        foreach (var value in values)
        {
            var converted = TResult.CreateChecked(value);

            //Console.WriteLine($"Converted: {converted}");

            result += converted;
        }

        return result;
    }

    public static T Sum<T>(IEnumerable<T> values) where T : INumber<T>
    {
        T result = T.Zero;

        foreach (var value in values)
        {
            result += value;
        }

        return result;
    }
}