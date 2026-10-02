using PCBToolkit.Models;

namespace PCBToolkit.Data;

public static class SmdPackageData
{
    public static List<SmdPackage> GetPackages()
    {
        return new List<SmdPackage>
        {
            new()
            {
                ImperialCode = "01005",
                MetricCode = "0402",
                LengthMm = 0.4,
                WidthMm = 0.2,
                Description = "Ultra-minyatür SMD chip paketi."
            },

            new()
            {
                ImperialCode = "0201",
                MetricCode = "0603",
                LengthMm = 0.6,
                WidthMm = 0.3,
                Description = "Çok küçük SMD chip paketi."
            },

            new()
            {
                ImperialCode = "0402",
                MetricCode = "1005",
                LengthMm = 1.0,
                WidthMm = 0.5,
                Description = "Kompakt SMD chip paketi."
            },

            new()
            {
                ImperialCode = "0603",
                MetricCode = "1608",
                LengthMm = 1.6,
                WidthMm = 0.8,
                Description = "Yaygın kullanılan küçük SMD chip paketi."
            },

            new()
            {
                ImperialCode = "0805",
                MetricCode = "2012",
                LengthMm = 2.0,
                WidthMm = 1.25,
                Description = "Yaygın kullanılan orta boy SMD chip paketi."
            },

            new()
            {
                ImperialCode = "1206",
                MetricCode = "3216",
                LengthMm = 3.2,
                WidthMm = 1.6,
                Description = "Orta-büyük SMD chip paketi."
            },

            new()
            {
                ImperialCode = "1210",
                MetricCode = "3225",
                LengthMm = 3.2,
                WidthMm = 2.5,
                Description = "Geniş gövdeli SMD chip paketi."
            },

            new()
            {
                ImperialCode = "1812",
                MetricCode = "4532",
                LengthMm = 4.5,
                WidthMm = 3.2,
                Description = "Büyük SMD chip paketi."
            },

            new()
            {
                ImperialCode = "2010",
                MetricCode = "5025",
                LengthMm = 5.0,
                WidthMm = 2.5,
                Description = "Büyük ve yüksek güç uygulamalarında da kullanılan SMD chip paketi."
            },

            new()
            {
                ImperialCode = "2512",
                MetricCode = "6432",
                LengthMm = 6.4,
                WidthMm = 3.2,
                Description = "Büyük SMD chip paketlerinden biridir."
            }
        };
    }
}