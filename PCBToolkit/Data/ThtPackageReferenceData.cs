using PCBToolkit.Models;

namespace PCBToolkit.Data;

public static class ThtPackageReferenceData
{
    public static List<ThtPackageReference> GetReferences()
    {
        return new List<ThtPackageReference>
        {
            // =========================
            // AXIAL
            // =========================

            new ThtPackageReference
            {
                Family = "Axial",
                PackageName = "DIN 0207",
                Description = "Küçük gövdeli eksenel THT komponent sınıfı.",
                MountingType = "THT / Axial",
                PinCount = "2",
                LeadPitch = "Değişken",
                BodyType = "Silindirik / Axial",
                TypicalUsage = "Genel amaçlı ve düşük/orta güçlü dirençler",
                Note = "Vishay PR01 gibi ürünlerde kullanılan DIN boyut sınıfıdır. Bacaklar PCB delik aralığına göre şekillendirilebilir."
            },

            new ThtPackageReference
            {
                Family = "Axial",
                PackageName = "DIN 0411",
                Description = "0207'ye göre daha büyük eksenel THT gövde sınıfı.",
                MountingType = "THT / Axial",
                PinCount = "2",
                LeadPitch = "Değişken",
                BodyType = "Silindirik / Axial",
                TypicalUsage = "Daha yüksek güçlü eksenel dirençler",
                Note = "Vishay PR02 gibi güç dirençlerinde kullanılan DIN boyut sınıfıdır."
            },

            new ThtPackageReference
            {
                Family = "Axial",
                PackageName = "DIN 0617",
                Description = "Büyük eksenel THT gövde sınıfı.",
                MountingType = "THT / Axial",
                PinCount = "2",
                LeadPitch = "Değişken",
                BodyType = "Silindirik / Axial",
                TypicalUsage = "Yüksek güçlü eksenel dirençler",
                Note = "Vishay PR03 gibi güç dirençlerinde kullanılan DIN boyut sınıfıdır."
            },


            // =========================
            // RADIAL
            // =========================

            new ThtPackageReference
            {
                Family = "Radial",
                PackageName = "Ø5 mm",
                Description = "5 mm gövde çapına sahip radial komponent sınıfı.",
                MountingType = "THT / Radial",
                PinCount = "2",
                LeadPitch = "2.0 mm",
                BodyType = "Silindirik / Radial",
                TypicalUsage = "Alüminyum elektrolitik kapasitörler",
                Note = "Gövde yüksekliği kapasite, voltaj ve üretici serisine göre değişir."
            },

            new ThtPackageReference
            {
                Family = "Radial",
                PackageName = "Ø6.3 mm",
                Description = "6.3 mm gövde çapına sahip radial komponent sınıfı.",
                MountingType = "THT / Radial",
                PinCount = "2",
                LeadPitch = "2.5 mm",
                BodyType = "Silindirik / Radial",
                TypicalUsage = "Alüminyum elektrolitik kapasitörler",
                Note = "Gövde yüksekliği ürün serisine göre değişir."
            },

            new ThtPackageReference
            {
                Family = "Radial",
                PackageName = "Ø8 mm",
                Description = "8 mm gövde çapına sahip radial komponent sınıfı.",
                MountingType = "THT / Radial",
                PinCount = "2",
                LeadPitch = "3.5 mm",
                BodyType = "Silindirik / Radial",
                TypicalUsage = "Alüminyum elektrolitik kapasitörler",
                Note = "Nominal pin aralığı 3.5 mm'dir."
            },

            new ThtPackageReference
            {
                Family = "Radial",
                PackageName = "Ø10 mm",
                Description = "10 mm gövde çapına sahip radial komponent sınıfı.",
                MountingType = "THT / Radial",
                PinCount = "2",
                LeadPitch = "5.0 mm",
                BodyType = "Silindirik / Radial",
                TypicalUsage = "Alüminyum elektrolitik kapasitörler",
                Note = "Nominal pin aralığı 5.0 mm'dir."
            },

            new ThtPackageReference
            {
                Family = "Radial",
                PackageName = "Ø12.5 mm",
                Description = "12.5 mm gövde çapına sahip radial komponent sınıfı.",
                MountingType = "THT / Radial",
                PinCount = "2",
                LeadPitch = "5.0 mm",
                BodyType = "Silindirik / Radial",
                TypicalUsage = "Orta ve yüksek kapasiteli elektrolitik kapasitörler",
                Note = "Nominal pin aralığı 5.0 mm'dir."
            },

            new ThtPackageReference
            {
                Family = "Radial",
                PackageName = "Ø16 mm",
                Description = "16 mm gövde çapına sahip büyük radial komponent sınıfı.",
                MountingType = "THT / Radial",
                PinCount = "2",
                LeadPitch = "7.5 mm",
                BodyType = "Silindirik / Radial",
                TypicalUsage = "Yüksek kapasiteli elektrolitik kapasitörler",
                Note = "Nominal pin aralığı 7.5 mm'dir."
            },

            new ThtPackageReference
            {
                Family = "Radial",
                PackageName = "Ø18 mm",
                Description = "18 mm gövde çapına sahip büyük radial komponent sınıfı.",
                MountingType = "THT / Radial",
                PinCount = "2",
                LeadPitch = "7.5 mm",
                BodyType = "Silindirik / Radial",
                TypicalUsage = "Yüksek kapasiteli elektrolitik kapasitörler",
                Note = "Nominal pin aralığı 7.5 mm'dir."
            },


            // =========================
            // PDIP - 300 mil
            // =========================

            new ThtPackageReference
            {
                Family = "PDIP",
                PackageName = "PDIP-8 300 mil",
                Description = "8 pinli plastik Dual In-Line THT entegre paketi.",
                MountingType = "THT / Dual In-Line",
                PinCount = "8",
                LeadPitch = "2.54 mm",
                BodyType = "Dikdörtgen / Dual Row",
                TypicalUsage = "Op-amp, timer, küçük analog ve dijital entegreler",
                Note = "300 mil sınıfı. Gerçek gövde ve sıra ölçüleri üretici paket çizimine göre kontrol edilmelidir."
            },

            new ThtPackageReference
            {
                Family = "PDIP",
                PackageName = "PDIP-14 300 mil",
                Description = "14 pinli plastik Dual In-Line THT entegre paketi.",
                MountingType = "THT / Dual In-Line",
                PinCount = "14",
                LeadPitch = "2.54 mm",
                BodyType = "Dikdörtgen / Dual Row",
                TypicalUsage = "Lojik entegreler, analog devreler",
                Note = "Komşu pinler arasındaki nominal pitch 2.54 mm'dir."
            },

            new ThtPackageReference
            {
                Family = "PDIP",
                PackageName = "PDIP-16 300 mil",
                Description = "16 pinli plastik Dual In-Line THT entegre paketi.",
                MountingType = "THT / Dual In-Line",
                PinCount = "16",
                LeadPitch = "2.54 mm",
                BodyType = "Dikdörtgen / Dual Row",
                TypicalUsage = "Lojik, sürücü, analog ve kontrol entegreleri",
                Note = "300 mil sınıfında yaygın THT IC paketlerinden biridir."
            },

            new ThtPackageReference
            {
                Family = "PDIP",
                PackageName = "PDIP-18 300 mil",
                Description = "18 pinli plastik Dual In-Line THT entegre paketi.",
                MountingType = "THT / Dual In-Line",
                PinCount = "18",
                LeadPitch = "2.54 mm",
                BodyType = "Dikdörtgen / Dual Row",
                TypicalUsage = "Kontrol ve dijital entegreler",
                Note = "Gövde uzunluğu pin sayısıyla artar."
            },

            new ThtPackageReference
            {
                Family = "PDIP",
                PackageName = "PDIP-20 300 mil",
                Description = "20 pinli plastik Dual In-Line THT entegre paketi.",
                MountingType = "THT / Dual In-Line",
                PinCount = "20",
                LeadPitch = "2.54 mm",
                BodyType = "Dikdörtgen / Dual Row",
                TypicalUsage = "Dijital lojik, sürücü ve kontrol entegreleri",
                Note = "300 mil sınıfı için nominal pin pitch 2.54 mm'dir."
            },

            new ThtPackageReference
            {
                Family = "PDIP",
                PackageName = "PDIP-24 300 mil",
                Description = "24 pinli plastik Dual In-Line THT entegre paketi.",
                MountingType = "THT / Dual In-Line",
                PinCount = "24",
                LeadPitch = "2.54 mm",
                BodyType = "Dikdörtgen / Dual Row",
                TypicalUsage = "Mikrodenetleyici, bellek ve çeşitli kontrol entegreleri",
                Note = "24 pin PDIP'in farklı gövde genişlikleri de bulunabilir. PCB tasarımında üreticinin package drawing'i esas alınmalıdır."
            },


            // =========================
            // TO
            // =========================

            new ThtPackageReference
            {
                Family = "TO",
                PackageName = "TO-92",
                Description = "Küçük sinyal yarı iletkenlerinde kullanılan kompakt üç bacaklı THT paket.",
                MountingType = "THT",
                PinCount = "3",
                LeadPitch = "1.27 mm komşu pin pitch",
                BodyType = "Molded transistor package",
                TypicalUsage = "Küçük sinyal BJT, JFET, MOSFET ve regülatörler",
                Note = "Pin dizilimi komponentten komponente değişebilir. Datasheet pinout mutlaka kontrol edilmelidir."
            },

            new ThtPackageReference
            {
                Family = "TO",
                PackageName = "TO-126 / SOT-32",
                Description = "Orta güç yarı iletkenleri için üç bacaklı THT paket.",
                MountingType = "THT",
                PinCount = "3",
                LeadPitch = "≈2.29 mm tipik",
                BodyType = "Flat power transistor package",
                TypicalUsage = "Orta güç BJT ve benzeri güç yarı iletkenleri",
                Note = "ST SOT-32 çiziminde pin pitch yaklaşık 2.29 mm tipiktir; üretici varyantına göre tolerans bulunur."
            },

            new ThtPackageReference
            {
                Family = "TO",
                PackageName = "TO-220-3",
                Description = "Soğutucuya bağlanabilen yaygın üç bacaklı güç yarı iletken paketi.",
                MountingType = "THT",
                PinCount = "3",
                LeadPitch = "≈2.54 mm",
                BodyType = "Power package / Tabbed",
                TypicalUsage = "MOSFET, BJT, doğrultucu, lineer regülatör ve güç elemanları",
                Note = "Tab elektriksel olarak aktif olabilir. İzolasyon ve pin bağlantıları cihaz datasheet'inden kontrol edilmelidir."
            },

            new ThtPackageReference
            {
                Family = "TO",
                PackageName = "TO-247-3",
                Description = "Yüksek güç yarı iletkenlerinde kullanılan büyük üç bacaklı THT paket.",
                MountingType = "THT",
                PinCount = "3",
                LeadPitch = "≈5.45–5.56 mm",
                BodyType = "Large power package / Tabbed",
                TypicalUsage = "Yüksek güçlü MOSFET, IGBT ve güç diyotları",
                Note = "Pitch ve gövde ölçülerinde üretici case varyantları bulunur. ST örneklerinde yaklaşık 5.45 mm, bazı onsemi varyantlarında 5.56 mm görülür."
            }
        };
    }
}
