using System.Globalization;

namespace PCBToolkit.Services;

public static class NumberFormatService
{
    public static string Format(double value)
    {
        string decimalFormat =
            Preferences.Default.Get("DecimalFormat", "Virgül");

        CultureInfo culture = decimalFormat == "Nokta"
            ? CultureInfo.InvariantCulture
            : new CultureInfo("tr-TR");

        return value.ToString("0.###", culture);
    }
}
