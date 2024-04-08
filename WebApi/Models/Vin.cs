using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

public class Vin : IParsable<Vin>
{
    public string Country { get; private set; }
    public int ManufacturingCompany { get; private set; }
    public string VehicleInfo { get; private set; }
    public int SecurityCode { get; private set; }
    public string YearCode {get; private set; } 
    public string AssemblyFactory   { get; private set; }
    public string SerialNumber {get; private set; }

    public static Vin Parse(string vin, IFormatProvider? provider)
    {
        if (TryParse(vin, provider, out var result))
        {
            return result;
        }

        throw new ArgumentException("Could not parse VIN", nameof(vin));
    }

    public static bool TryParse([NotNullWhen(true)] string? vin, IFormatProvider? provider, [MaybeNullWhen(false)] out Vin result)
    {
        var regex = Regex.Match(vin, "^(\\w{2})(\\d)(.{5})(\\d)(\\w)(\\w)(\\d{6})", RegexOptions.IgnoreCase);

        if (regex.Success)
        {
            result = new Vin
            {
                Country = regex.Groups[1].Value,
                ManufacturingCompany = int.Parse(regex.Groups[2].Value),
                VehicleInfo = regex.Groups[3].Value,
                SecurityCode = int.Parse(regex.Groups[4].Value),
                YearCode = regex.Groups[5].Value,
                AssemblyFactory = regex.Groups[6].Value,
                SerialNumber = regex.Groups[7].Value
            };

            return true;
        }

        result = default;

        return false;
    }
}