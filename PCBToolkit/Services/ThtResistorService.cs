namespace PCBToolkit.Services;

public class ThtResistorService
{
    private static readonly Dictionary<string, int> DigitValues = new()
    {
        { "Siyah", 0 },
        { "Kahverengi", 1 },
        { "Kırmızı", 2 },
        { "Turuncu", 3 },
        { "Sarı", 4 },
        { "Yeşil", 5 },
        { "Mavi", 6 },
        { "Mor", 7 },
        { "Gri", 8 },
        { "Beyaz", 9 }
    };

    private static readonly Dictionary<string, double> Multipliers = new()
    {
        { "Siyah", 1 },
        { "Kahverengi", 10 },
        { "Kırmızı", 100 },
        { "Turuncu", 1_000 },
        { "Sarı", 10_000 },
        { "Yeşil", 100_000 },
        { "Mavi", 1_000_000 },
        { "Mor", 10_000_000 },
        { "Gri", 100_000_000 },
        { "Beyaz", 1_000_000_000 },
        { "Altın", 0.1 },
        { "Gümüş", 0.01 }
    };

    private static readonly Dictionary<string, double> Tolerances = new()
    {
        { "Kahverengi", 1 },
        { "Kırmızı", 2 },
        { "Yeşil", 0.5 },
        { "Mavi", 0.25 },
        { "Mor", 0.1 },
        { "Gri", 0.05 },
        { "Altın", 5 },
        { "Gümüş", 10 },
        { "Renksiz", 20 }
    };

    private static readonly Dictionary<string, int> TemperatureCoefficients = new()
    {
        { "Kahverengi", 100 },
        { "Kırmızı", 50 },
        { "Turuncu", 15 },
        { "Sarı", 25 },
        { "Mavi", 10 },
        { "Mor", 5 }
    };

    public double Calculate4Band(
        string band1,
        string band2,
        string multiplier)
    {
        int first = GetDigit(band1);
        int second = GetDigit(band2);

        double multiplierValue = GetMultiplier(multiplier);

        return ((first * 10) + second) * multiplierValue;
    }

    public double Calculate5Or6Band(
        string band1,
        string band2,
        string band3,
        string multiplier)
    {
        int first = GetDigit(band1);
        int second = GetDigit(band2);
        int third = GetDigit(band3);

        double multiplierValue = GetMultiplier(multiplier);

        return ((first * 100) + (second * 10) + third)
               * multiplierValue;
    }

    public double GetTolerance(string color)
    {
        if (!Tolerances.TryGetValue(color, out double value))
            throw new ArgumentException("Geçersiz tolerans rengi.");

        return value;
    }

    public int GetTemperatureCoefficient(string color)
    {
        if (!TemperatureCoefficients.TryGetValue(color, out int value))
            throw new ArgumentException("Geçersiz sıcaklık katsayısı rengi.");

        return value;
    }

    private static int GetDigit(string color)
    {
        if (!DigitValues.TryGetValue(color, out int value))
            throw new ArgumentException("Geçersiz değer bandı rengi.");

        return value;
    }

    private static double GetMultiplier(string color)
    {
        if (!Multipliers.TryGetValue(color, out double value))
            throw new ArgumentException("Geçersiz çarpan bandı rengi.");

        return value;
    }
}
