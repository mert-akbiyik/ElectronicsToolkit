using PCBToolkit.Models;

namespace PCBToolkit.Data;

public static class SmdPackageReferenceData
{
    public static List<SmdPackageReference> GetPackages()
    {
        return new List<SmdPackageReference>
        {
            // =========================
            // SOT
            // =========================

            new()
            {
                Family = "SOT",
                PackageName = "SOT-23",
                Description = "Kompakt Small Outline Transistor paketi.",
                MountingType = "SMD",
                PinType = "Lead",
                TypicalPinCount = "3",
                TypicalPitch = "1.9 mm",
                TypicalUsage = "Transistörler, diyotlar, MOSFET ve koruma elemanları"
            },

            new()
            {
                Family = "SOT",
                PackageName = "SOT-89",
                Description = "Isı transferine uygun daha büyük SOT paketi.",
                MountingType = "SMD",
                PinType = "Lead",
                TypicalPinCount = "3",
                TypicalPitch = "1.5 mm",
                TypicalUsage = "Transistörler, regülatörler ve güç elemanları"
            },

            new()
            {
                Family = "SOT",
                PackageName = "SOT-223",
                Description = "Artırılmış ısı dağıtımı sağlayan SMD güç paketi.",
                MountingType = "SMD",
                PinType = "Lead / heatsink tab",
                TypicalPinCount = "4",
                TypicalPitch = "2.3 mm",
                TypicalUsage = "Regülatörler, transistörler ve güç uygulamaları"
            },

            // =========================
            // SOIC
            // =========================

            new()
            {
                Family = "SOIC",
                PackageName = "SOIC-8",
                Description = "8 pin Small Outline Integrated Circuit paketi.",
                MountingType = "SMD",
                PinType = "Gull-wing",
                TypicalPinCount = "8",
                TypicalPitch = "1.27 mm",
                TypicalUsage = "Op-amp, sensör, hafıza ve kontrol entegreleri"
            },

            new()
            {
                Family = "SOIC",
                PackageName = "SOIC-14",
                Description = "14 pin Small Outline Integrated Circuit paketi.",
                MountingType = "SMD",
                PinType = "Gull-wing",
                TypicalPinCount = "14",
                TypicalPitch = "1.27 mm",
                TypicalUsage = "Analog ve dijital entegre devreler"
            },

            new()
            {
                Family = "SOIC",
                PackageName = "SOIC-16",
                Description = "16 pin Small Outline Integrated Circuit paketi.",
                MountingType = "SMD",
                PinType = "Gull-wing",
                TypicalPinCount = "16",
                TypicalPitch = "1.27 mm",
                TypicalUsage = "Analog ve dijital entegre devreler"
            },

            // =========================
            // QFN
            // =========================

            new()
            {
                Family = "QFN",
                PackageName = "QFN-24",
                Description = "24 bağlantılı Quad Flat No-Lead paketi.",
                MountingType = "SMD",
                PinType = "Leadless",
                TypicalPinCount = "24",
                TypicalPitch = "0.5 mm",
                TypicalUsage = "Mikrodenetleyici, analog ve güç entegreleri"
            },

            new()
            {
                Family = "QFN",
                PackageName = "QFN-32",
                Description = "32 bağlantılı Quad Flat No-Lead paketi.",
                MountingType = "SMD",
                PinType = "Leadless",
                TypicalPinCount = "32",
                TypicalPitch = "0.5 mm",
                TypicalUsage = "Mikrodenetleyici, RF ve güç entegreleri"
            },

            new()
            {
                Family = "QFN",
                PackageName = "QFN-48",
                Description = "48 bağlantılı Quad Flat No-Lead paketi.",
                MountingType = "SMD",
                PinType = "Leadless",
                TypicalPinCount = "48",
                TypicalPitch = "0.5 mm",
                TypicalUsage = "Mikrodenetleyici ve yüksek yoğunluklu entegreler"
            },

            // =========================
            // QFP
            // =========================

            new()
            {
                Family = "QFP",
                PackageName = "LQFP-48",
                Description = "48 pin Low-profile Quad Flat Package.",
                MountingType = "SMD",
                PinType = "Gull-wing",
                TypicalPinCount = "48",
                TypicalPitch = "0.5 mm",
                TypicalUsage = "Mikrodenetleyiciler ve kontrol entegreleri"
            },

            new()
            {
                Family = "QFP",
                PackageName = "LQFP-64",
                Description = "64 pin Low-profile Quad Flat Package.",
                MountingType = "SMD",
                PinType = "Gull-wing",
                TypicalPinCount = "64",
                TypicalPitch = "0.5 mm",
                TypicalUsage = "Mikrodenetleyiciler, işlemciler ve kontrol entegreleri"
            },

            // =========================
            // BGA
            // =========================

            new()
            {
                Family = "BGA",
                PackageName = "FBGA",
                Description = "Fine-pitch Ball Grid Array ailesi.",
                MountingType = "SMD",
                PinType = "Solder ball array",
                TypicalPinCount = "Pakete göre değişir",
                TypicalPitch = "Genellikle 1.0 mm",
                TypicalUsage = "FPGA, işlemci, bellek ve yüksek pin sayılı entegreler"
            },

            new()
            {
                Family = "BGA",
                PackageName = "VFBGA",
                Description = "Very Fine-pitch Ball Grid Array ailesi.",
                MountingType = "SMD",
                PinType = "Solder ball array",
                TypicalPinCount = "Pakete göre değişir",
                TypicalPitch = "Genellikle 0.8 mm",
                TypicalUsage = "FPGA, işlemci ve yoğun bağlantılı entegreler"
            },

            // =========================
            // LGA
            // =========================

            new()
            {
                Family = "LGA",
                PackageName = "LGA",
                Description = "Land Grid Array paket ailesi.",
                MountingType = "SMD",
                PinType = "Land array",
                TypicalPinCount = "Pakete göre değişir",
                TypicalPitch = "Pakete göre değişir",
                TypicalUsage = "Sensörler, RF entegreleri ve yüksek yoğunluklu devreler"
            }
        };
    }
}