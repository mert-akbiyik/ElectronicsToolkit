namespace PCBToolkit.Models;

public class SmdPackage
{
    public string ImperialCode { get; set; } = string.Empty;

    public string MetricCode { get; set; } = string.Empty;

    public double LengthMm { get; set; }

    public double WidthMm { get; set; }

    public string Description { get; set; } = string.Empty;
}