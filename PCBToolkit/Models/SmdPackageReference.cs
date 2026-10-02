namespace PCBToolkit.Models;

public class SmdPackageReference
{
    public string Family { get; set; } = string.Empty;

    public string PackageName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string MountingType { get; set; } = string.Empty;

    public string PinType { get; set; } = string.Empty;

    public string TypicalPinCount { get; set; } = string.Empty;

    public string TypicalPitch { get; set; } = string.Empty;

    public string TypicalUsage { get; set; } = string.Empty;
}