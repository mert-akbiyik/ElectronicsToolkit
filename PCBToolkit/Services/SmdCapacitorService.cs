namespace PCBToolkit.Services;

public class SmdCapacitorService
{
    public double CalculatePicofarads(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Kapasitör kodu boş olamaz.");

        code = code.Trim();

        if (!code.All(char.IsDigit))
            throw new ArgumentException("Kapasitör kodu yalnızca rakamlardan oluşmalıdır.");

        if (code.Length != 3)
            throw new ArgumentException("Kapasitör kodu 3 haneli olmalıdır.");

        int significantValue = int.Parse(code[..2]);
        int multiplier = int.Parse(code[2].ToString());

        return significantValue * Math.Pow(10, multiplier);
    }
}