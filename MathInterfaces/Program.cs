using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        // simple examples
        int sum1 = Sum(5, 20);
        double sum2 = Sum(5.6, 20.3);

        var numbers = new[] { 1, 2, 3, 4, 247 };
        var decimals = new[] { 1.9m, 3.6m, 5.3m };

        int sum3 = Sum(numbers);
        byte sum4 = Sum<int, byte>(numbers);
        decimal sum5 = Sum(decimals);
        int sum6 = Sum<decimal, int>(decimals);

        Console.WriteLine("\nSumming two integers");
        Console.WriteLine(sum1);
        Console.WriteLine(sum1.GetType().Name);

        Console.WriteLine("\nSumming two doubles");
        Console.WriteLine(sum2);
        Console.WriteLine(sum2.GetType().Name);

        Console.WriteLine("\nSumming array of ints");
        Console.WriteLine(sum3);
        Console.WriteLine(sum3.GetType().Name);

        Console.WriteLine("\nSumming array of ints and as a byte");
        Console.WriteLine(sum4);
        Console.WriteLine(sum4.GetType().Name);

        Console.WriteLine("\nSumming array of decimals");
        Console.WriteLine(sum5);
        Console.WriteLine(sum5.GetType().Name);
        
        Console.WriteLine("\nSumming array of decimals and as a int");
        Console.WriteLine(sum6);
        Console.WriteLine(sum6.GetType().Name);
    }

    public static TResult Sum<T, TResult>(IEnumerable<T> values) where T : INumber<T> where TResult : INumber<TResult>
    {
        TResult result = TResult.Zero;

        foreach (var value in values)
        {
            var converted = TResult.CreateChecked(value);

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

    public static T Sum<T>(T left, T right) where T : INumber<T>
    {
        return left + right;
    }
}