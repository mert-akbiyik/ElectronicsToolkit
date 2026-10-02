namespace PCBToolkit.Services;

public class SmdResistorService
{
    public double CalculateStandardCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Direnç kodu boş olamaz.");

        code = code.Trim();

        if (!code.All(char.IsDigit))
            throw new ArgumentException("Standart direnç kodu yalnızca rakamlardan oluşmalıdır.");

        if (code.Length == 3)
        {
            int significantValue = int.Parse(code[..2]);
            int multiplier = int.Parse(code[2].ToString());

            return significantValue * Math.Pow(10, multiplier);
        }

        if (code.Length == 4)
        {
            int significantValue = int.Parse(code[..3]);
            int multiplier = int.Parse(code[3].ToString());

            return significantValue * Math.Pow(10, multiplier);
        }

        throw new ArgumentException("Standart SMD kodu 3 veya 4 haneli olmalıdır.");
    }
    public double CalculateRCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Direnç kodu boş olamaz.");

        code = code.Trim().ToUpperInvariant();

        if (!code.Contains('R'))
            throw new ArgumentException("R kodu 'R' karakteri içermelidir.");

        if (code.Count(c => c == 'R') != 1)
            throw new ArgumentException("Geçersiz R kodu.");

        string numericValue = code.Replace('R', '.');

        if (!double.TryParse(
                numericValue,
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture,
                out double resistance))
        {
            throw new ArgumentException("Geçersiz R kodu.");
        }

        return resistance;
    }
    private static readonly int[] E96Values =
{
    100, 102, 105, 107, 110, 113, 115, 118,
    121, 124, 127, 130, 133, 137, 140, 143,
    147, 150, 154, 158, 162, 165, 169, 174,
    178, 182, 187, 191, 196, 200, 205, 210,
    215, 221, 226, 232, 237, 243, 249, 255,
    261, 267, 274, 280, 287, 294, 301, 309,
    316, 324, 332, 340, 348, 357, 365, 374,
    383, 392, 402, 412, 422, 432, 442, 453,
    464, 475, 487, 499, 511, 523, 536, 549,
    562, 576, 590, 604, 619, 634, 649, 665,
    681, 698, 715, 732, 750, 768, 787, 806,
    825, 845, 866, 887, 909, 931, 953, 976
};

    private static readonly Dictionary<char, double> E96Multipliers =
        new()
        {
        { 'Z', 0.001 },
        { 'Y', 0.01 },
        { 'R', 0.01 },
        { 'X', 0.1 },
        { 'S', 0.1 },
        { 'A', 1 },
        { 'B', 10 },
        { 'H', 10 },
        { 'C', 100 },
        { 'D', 1_000 },
        { 'E', 10_000 },
        { 'F', 100_000 }
        };

    public double CalculateEia96(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Direnç kodu boş olamaz.");

        code = code.Trim().ToUpperInvariant();

        if (code.Length != 3)
            throw new ArgumentException("EIA-96 kodu 3 karakter olmalıdır.");

        if (!int.TryParse(code[..2], out int index))
            throw new ArgumentException("EIA-96 kodunun ilk iki karakteri rakam olmalıdır.");

        if (index < 1 || index > 96)
            throw new ArgumentException("EIA-96 sayı kodu 01 ile 96 arasında olmalıdır.");

        char multiplierCode = code[2];

        if (!E96Multipliers.TryGetValue(multiplierCode, out double multiplier))
            throw new ArgumentException("Geçersiz EIA-96 çarpan harfi.");

        int baseValue = E96Values[index - 1];

        return baseValue * multiplier;
    }
}