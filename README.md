# Electronics Toolkit

**Electronics Toolkit**, elektronik devre tasarımı ve PCB geliştirme süreçlerinde sık kullanılan hesaplama ve referans araçlarını tek bir mobil uygulamada bir araya getiren, **.NET MAUI** ile geliştirilmiş bir elektronik yardımcı araç uygulamasıdır.

Uygulama, **SMD (Surface Mount Device)** ve **THT (Through-Hole Technology)** bileşenleri için ayrı araç grupları sunar. Hesaplama, bileşen tanımlama ve paket referansı gibi işlemlerin mobil ortamda hızlı ve kolay şekilde gerçekleştirilebilmesi amaçlanmıştır.

---

## ✨ Özellikler

### 🔵 SMD Araçları

- SMD direnç kodu hesaplama ve çözümleme
- SMD kapasitör kodu hesaplama ve çözümleme
- SMD paket bulucu
- SMD paket referans bilgileri
- SMD bileşenleri için yardımcı hesaplama ve referans araçları

### 🟠 THT Araçları

- 4 bant direnç renk kodu hesaplama
- 5 bant direnç renk kodu hesaplama
- 6 bant direnç renk kodu hesaplama
- Direnç değeri, tolerans ve TCR bilgileri
- THT paket bulucu
- THT paket referans bilgileri
- LED hesaplama araçları
- THT bileşenleri için yardımcı hesaplama ve referans araçları

---

## 🎨 Kullanıcı Arayüzü

Electronics Toolkit, mobil kullanım öncelikli olarak tasarlanmıştır.

- Koyu tema
- SMD için mavi/cyan tasarım dili
- THT için turuncu/copper tasarım dili
- Responsive ekran yapıları
- Kaydırılabilir içerik alanları
- Mikro animasyonlar ve etkileşim geri bildirimleri
- Haptic feedback
- SMD ve THT bölümleri arasında özel ana ekran geçişi
- Uygulama genelinde tutarlı kart ve navigasyon yapısı

---

## 🛠️ Kullanılan Teknolojiler

- **C#**
- **.NET 10**
- **.NET MAUI**
- **XAML**
- **MVVM tabanlı proje organizasyonu**
- **MAUI Animation API**
- **Shell Navigation**
- **Android**

---

## 🏗️ Proje Yapısı

Proje, sorumlulukların ayrılması ve kodun sürdürülebilir tutulması amacıyla farklı katman ve klasörlere ayrılmıştır.

```text
PCBToolkit/
│
├── Data/
├── Models/
├── Platforms/
├── Resources/
├── Services/
├── Views/
│
├── App.xaml
├── App.xaml.cs
├── AppShell.xaml
├── AppShell.xaml.cs
├── MainPage.xaml
├── MainPage.xaml.cs
├── MauiProgram.cs
└── PCBToolkit.csproj
```

### Temel bölümler

**Models**  
Uygulamada kullanılan veri modellerini içerir.

**Data**  
Elektronik bileşenlere ve uygulama içi referans verilerine ilişkin veri yapılarını içerir.

**Services**  
Uygulamanın servis ve yardımcı işlem katmanlarını içerir.

**Views**  
SMD, THT, ayarlar ve diğer kullanıcı arayüzü ekranlarını içerir.

**Resources**  
Uygulama ikonları, splash screen, görseller ve diğer kaynak dosyalarını içerir.

---

## 📱 Platform

Uygulama **.NET MAUI** altyapısıyla geliştirilmiştir ve mevcut sürüm ağırlıklı olarak **Android** platformunda geliştirilip test edilmiştir.

Responsive tasarım sayesinde farklı mobil ekran boyutlarına uyum sağlayacak şekilde hazırlanmıştır.

---

## 🚀 Projeyi Çalıştırma

Projeyi yerel ortamınızda çalıştırmak için:

1. Repository'yi klonlayın.
2. `PCBToolkit.slnx` dosyasını Visual Studio ile açın.
3. Gerekli .NET MAUI workload'larının kurulu olduğundan emin olun.
4. Android emulator veya fiziksel Android cihaz seçin.
5. Projeyi build edip çalıştırın.

### Gereksinimler

- Visual Studio 2022
- .NET 10 SDK
- .NET MAUI workload
- Android SDK / Emulator

---

## 🎯 Projenin Amacı

Electronics Toolkit'in temel amacı, elektronik ile ilgilenen kullanıcıların farklı kaynaklar arasında geçiş yapmak yerine sık kullanılan elektronik hesaplama ve referans araçlarına tek bir uygulama üzerinden erişebilmesini sağlamaktır.

Proje aynı zamanda **.NET MAUI ile mobil uygulama geliştirme, responsive XAML tasarımı, kullanıcı etkileşimleri, navigasyon, animasyonlar ve C# tabanlı uygulama mimarisi** üzerine uygulamalı bir geliştirme çalışmasıdır.

---

## 📌 Durum

**Geliştirme durumu:** Tamamlandı ✅

- SMD araçları ✅
- THT araçları ✅
- Hesaplama ve veri işlemleri ✅
- Responsive UI/UX ✅
- Mikro animasyonlar ✅
- Navigasyon ✅
- Uygulama ikonu ✅
- Splash screen ✅
- Final testleri ve bugfixler ✅

---

## 👨‍💻 Geliştirici

**Mert Akbıyık**

.NET Developer

Bu proje, elektronik alanındaki teknik ihtiyaçların yazılım geliştirme ile bir araya getirilmesi amacıyla geliştirilmiştir.
