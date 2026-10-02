namespace PCBToolkit.Services;

public class LedResistorService
{
    public double CalculateResistance(
        double supplyVoltage,
        double ledVoltage,
        double ledCurrentMilliamp)
    {
        if (supplyVoltage <= 0)
            throw new ArgumentException("Besleme voltajı 0'dan büyük olmalıdır.");

        if (ledVoltage <= 0)
            throw new ArgumentException("LED voltajı 0'dan büyük olmalıdır.");

        if (ledCurrentMilliamp <= 0)
            throw new ArgumentException("LED akımı 0'dan büyük olmalıdır.");

        if (supplyVoltage <= ledVoltage)
            throw new ArgumentException(
                "Besleme voltajı LED voltajından büyük olmalıdır.");

        double currentAmp =
            ledCurrentMilliamp / 1000.0;

        return (supplyVoltage - ledVoltage) / currentAmp;
    }

    public double CalculatePower(
        double resistance,
        double ledCurrentMilliamp)
    {
        double currentAmp =
            ledCurrentMilliamp / 1000.0;

        return currentAmp * currentAmp * resistance;
    }
}