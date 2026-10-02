using PCBToolkit.Models;

namespace PCBToolkit.Data;

public static class ThtPackageData
{
    public static List<ThtPackage> GetPackages()
    {
        return new List<ThtPackage>
        {
            // =========================
            // AXIAL
            // =========================

            new()
            {
                Family = "Axial",
                PackageName = "DIN 0207",
                BodySize = "Max. 6.5 × Ø2.5 mm",
                PinCount = "2",
                LeadPitch = "Değişken",
                Diameter = "Max. 2.5 mm",
                MountingType = "THT / Axial",
                Description = "Küçük axial gövdeli direnç tipi.",
                Note = "Gövde ve bacak ölçüleri üretici/seri toleranslarına göre değişebilir."
            },

            new()
            {
                Family = "Axial",
                PackageName = "DIN 0411",
                BodySize = "10.0 × Ø3.9 mm",
                PinCount = "2",
                LeadPitch = "Değişken",
                Diameter = "3.9 mm",
                MountingType = "THT / Axial",
                Description = "Orta boy axial gövdeli direnç tipi.",
                Note = "Nominal gövde ölçüsüdür."
            },

            new()
            {
                Family = "Axial",
                PackageName = "DIN 0617",
                BodySize = "16.7 × Ø5.2 mm",
                PinCount = "2",
                LeadPitch = "Değişken",
                Diameter = "5.2 mm",
                MountingType = "THT / Axial",
                Description = "Daha büyük axial gövdeli direnç tipi.",
                Note = "Nominal gövde ölçüsüdür."
            },

            // =========================
            // RADIAL
            // =========================

            new()
            {
                Family = "Radial",
                PackageName = "Ø5",
                BodySize = "Ø5 mm",
                PinCount = "2",
                LeadPitch = "2.0 mm",
                Diameter = "5 mm",
                MountingType = "THT / Radial",
                Description = "5 mm çaplı radial komponent gövdesi.",
                Note = "Gövde yüksekliği ürün serisi, kapasite ve gerilime göre değişir."
            },

            new()
            {
                Family = "Radial",
                PackageName = "Ø6.3",
                BodySize = "Ø6.3 mm",
                PinCount = "2",
                LeadPitch = "2.5 mm",
                Diameter = "6.3 mm",
                MountingType = "THT / Radial",
                Description = "6.3 mm çaplı radial komponent gövdesi.",
                Note = "Gövde yüksekliği ürüne göre değişir."
            },

            new()
            {
                Family = "Radial",
                PackageName = "Ø8",
                BodySize = "Ø8 mm",
                PinCount = "2",
                LeadPitch = "3.5 mm",
                Diameter = "8 mm",
                MountingType = "THT / Radial",
                Description = "8 mm çaplı radial komponent gövdesi.",
                Note = "Bazı üretici ve serilerde lead pitch farklı olabilir."
            },

            new()
            {
                Family = "Radial",
                PackageName = "Ø10",
                BodySize = "Ø10 mm",
                PinCount = "2",
                LeadPitch = "5.0 mm",
                Diameter = "10 mm",
                MountingType = "THT / Radial",
                Description = "10 mm çaplı radial komponent gövdesi.",
                Note = "Gövde yüksekliği ürüne göre değişir."
            },

            new()
            {
                Family = "Radial",
                PackageName = "Ø12.5",
                BodySize = "Ø12.5 mm",
                PinCount = "2",
                LeadPitch = "5.0 mm",
                Diameter = "12.5 mm",
                MountingType = "THT / Radial",
                Description = "12.5 mm çaplı radial komponent gövdesi.",
                Note = "Üretici ve seriye göre mekanik ölçüler kontrol edilmelidir."
            },

            new()
            {
                Family = "Radial",
                PackageName = "Ø16",
                BodySize = "Ø16 mm",
                PinCount = "2",
                LeadPitch = "7.5 mm",
                Diameter = "16 mm",
                MountingType = "THT / Radial",
                Description = "16 mm çaplı büyük radial komponent gövdesi.",
                Note = "Gövde yüksekliği ürüne göre değişir."
            },

            new()
            {
                Family = "Radial",
                PackageName = "Ø18",
                BodySize = "Ø18 mm",
                PinCount = "2",
                LeadPitch = "7.5 mm",
                Diameter = "18 mm",
                MountingType = "THT / Radial",
                Description = "18 mm çaplı büyük radial komponent gövdesi.",
                Note = "Üretici ve seriye göre mekanik ölçüler değişebilir."
            },

            // =========================
            // PDIP
            // =========================

            new()
            {
                Family = "PDIP",
                PackageName = "PDIP-8 300 mil",
                BodySize = "Yaklaşık 9.53 × 6.35 mm",
                PinCount = "8",
                LeadPitch = "2.54 mm",
                Diameter = "—",
                MountingType = "THT / Dual In-Line",
                Description = "8 pin 300 mil Plastic Dual In-Line Package.",
                Note = "Gövde ölçüleri üretici ve paket standardına göre küçük farklılıklar gösterebilir."
            },

            new()
            {
                Family = "PDIP",
                PackageName = "PDIP-14 300 mil",
                BodySize = "Yaklaşık 19.05 × 6.35 mm",
                PinCount = "14",
                LeadPitch = "2.54 mm",
                Diameter = "—",
                MountingType = "THT / Dual In-Line",
                Description = "14 pin 300 mil Plastic Dual In-Line Package.",
                Note = "Pinler iki paralel sıra halinde bulunur."
            },

            new()
            {
                Family = "PDIP",
                PackageName = "PDIP-16 300 mil",
                BodySize = "Yaklaşık 19.05 × 6.35 mm",
                PinCount = "16",
                LeadPitch = "2.54 mm",
                Diameter = "—",
                MountingType = "THT / Dual In-Line",
                Description = "16 pin 300 mil Plastic Dual In-Line Package.",
                Note = "Yaygın kullanılan THT entegre paketlerinden biridir."
            },

            new()
            {
                Family = "PDIP",
                PackageName = "PDIP-18 300 mil",
                BodySize = "Yaklaşık 22.61 × 6.35 mm",
                PinCount = "18",
                LeadPitch = "2.54 mm",
                Diameter = "—",
                MountingType = "THT / Dual In-Line",
                Description = "18 pin 300 mil Plastic Dual In-Line Package.",
                Note = "Mekanik toleranslar üreticiye göre değişebilir."
            },

            new()
            {
                Family = "PDIP",
                PackageName = "PDIP-20 300 mil",
                BodySize = "Yaklaşık 25.91 × 6.35 mm",
                PinCount = "20",
                LeadPitch = "2.54 mm",
                Diameter = "—",
                MountingType = "THT / Dual In-Line",
                Description = "20 pin 300 mil Plastic Dual In-Line Package.",
                Note = "300 mil gövde genişliği sınıfındadır."
            },

            new()
            {
                Family = "PDIP",
                PackageName = "PDIP-24 300 mil",
                BodySize = "Yaklaşık 31.75 × 6.35 mm",
                PinCount = "24",
                LeadPitch = "2.54 mm",
                Diameter = "—",
                MountingType = "THT / Dual In-Line",
                Description = "24 pin 300 mil Plastic Dual In-Line Package.",
                Note = "24 pin DIP paketlerin wide-body varyantları da bulunduğundan gövde genişliği önemlidir."
            },

            // =========================
            // TO
            // =========================

            new()
            {
                Family = "TO",
                PackageName = "TO-92",
                BodySize = "Yaklaşık 4.7 × 3.7 mm",
                PinCount = "3",
                LeadPitch = "1.27 mm",
                Diameter = "—",
                MountingType = "THT",
                Description = "Kompakt 3 pin transistor outline paketi.",
                Note = "Transistör, sensör ve düşük güçlü yarı iletkenlerde yaygın olarak kullanılır."
            },

            new()
            {
                Family = "TO",
                PackageName = "TO-126",
                BodySize = "Yaklaşık 10.5–11.05 × 7.4–7.8 × 2.4–2.9 mm",
                PinCount = "3",
                LeadPitch = "2.28 mm",
                Diameter = "—",
                MountingType = "THT",
                Description = "Orta güç uygulamalarında kullanılan transistor outline paketi.",
                Note = "SOT-32 olarak da karşılaşılabilir. Mekanik ölçüler üreticiye göre değişebilir."
            },

            new()
            {
                Family = "TO",
                PackageName = "TO-220-3",
                BodySize = "Yaklaşık 15.25–15.75 × 10.0–10.4 × 4.4–4.6 mm",
                PinCount = "3",
                LeadPitch = "2.54 mm",
                Diameter = "—",
                MountingType = "THT",
                Description = "Soğutucu bağlantısına uygun yaygın güç yarı iletkeni paketi.",
                Note = "MOSFET, transistör, regülatör ve güç elemanlarında yaygındır. TO-220 ailesinin farklı pin sayılı varyantları da vardır."
            },

            new()
            {
                Family = "TO",
                PackageName = "TO-247-3",
                BodySize = "Yaklaşık 19.85–20.15 × 15.45–15.75 × 4.85–5.15 mm",
                PinCount = "3",
                LeadPitch = "5.45 mm",
                Diameter = "—",
                MountingType = "THT",
                Description = "Yüksek güçlü yarı iletkenler için kullanılan büyük transistor outline paketi.",
                Note = "Güç MOSFET'leri, IGBT'ler ve benzeri yüksek güçlü elemanlarda yaygındır."
            }
        };
    }
}
