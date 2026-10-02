using System.Globalization;
using PCBToolkit.Services;

namespace PCBToolkit.Views;

public partial class ThtLedResistorPage : ContentPage
{
    private readonly LedResistorService _ledResistorService;

    public ThtLedResistorPage()
    {
        InitializeComponent();

        _ledResistorService =
            new LedResistorService();

        ResetLedVisual();
    }

    // EN: Calculates the resistor value and updates the LED preview
    // TR: Direnç değerini hesaplar ve LED önizlemesini günceller
    private async void OnCalculateClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            CalculateButton);

        try
        {
            double supplyVoltage =
                ParseValue(
                    SupplyVoltageEntry.Text,
                    "Besleme voltajını girin.");

            double ledVoltage =
                ParseValue(
                    LedVoltageEntry.Text,
                    "LED ileri yön voltajını girin.");

            double ledCurrent =
                ParseValue(
                    LedCurrentEntry.Text,
                    "LED akımını girin.");

            ValidateValues(
                supplyVoltage,
                ledVoltage,
                ledCurrent);

            double resistance =
                _ledResistorService.CalculateResistance(
                    supplyVoltage,
                    ledVoltage,
                    ledCurrent);

            double power =
                _ledResistorService.CalculatePower(
                    resistance,
                    ledCurrent);

            ResistanceResultLabel.Text =
                $"{NumberFormatService.Format(resistance)} Ω";

            PowerResultLabel.Text =
                $"{NumberFormatService.Format(power)} W";

            CalculationLabel.Text =
                $"({NumberFormatService.Format(supplyVoltage)} - " +
                $"{NumberFormatService.Format(ledVoltage)}) / " +
                $"{NumberFormatService.Format(ledCurrent)} mA";

            UpdateLedVisual(
                ledVoltage);

            await Task.WhenAll(
                AnimateResultAsync(),
                AnimateLedAsync());
        }
        catch (ArgumentException ex)
        {
            ResistanceResultLabel.Text =
                "Hatalı Değer";

            PowerResultLabel.Text =
                "— W";

            CalculationLabel.Text =
                ex.Message;

            ResetLedVisual();

            await AnimateResultAsync();
        }
    }

    // EN: Clears all input, result and LED preview values
    // TR: Tüm giriş, sonuç ve LED önizleme değerlerini temizler
    private async void OnClearClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            ClearButton);

        SupplyVoltageEntry.Text =
            string.Empty;

        LedVoltageEntry.Text =
            string.Empty;

        LedCurrentEntry.Text =
            string.Empty;

        ResistanceResultLabel.Text =
            "— Ω";

        PowerResultLabel.Text =
            "— W";

        CalculationLabel.Text =
            "—";

        ResetLedVisual();

        SupplyVoltageEntry.Focus();
    }

    // EN: Validates circuit values before calculation
    // TR: Hesaplamadan önce devre değerlerini doğrular
    private static void ValidateValues(
        double supplyVoltage,
        double ledVoltage,
        double ledCurrent)
    {
        if (supplyVoltage <= 0)
        {
            throw new ArgumentException(
                "Besleme voltajı 0 V'tan büyük olmalıdır.");
        }

        if (ledVoltage <= 0)
        {
            throw new ArgumentException(
                "LED ileri yön voltajı 0 V'tan büyük olmalıdır.");
        }

        if (ledCurrent <= 0)
        {
            throw new ArgumentException(
                "LED akımı 0 mA'den büyük olmalıdır.");
        }

        if (ledVoltage >= supplyVoltage)
        {
            throw new ArgumentException(
                "Besleme voltajı LED ileri yön voltajından büyük olmalıdır.");
        }
    }

    // EN: Parses numeric input using invariant decimal formatting
    // TR: Sayısal girişi bağımsız ondalık format kullanarak dönüştürür
    private static double ParseValue(
        string? text,
        string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException(
                errorMessage);
        }

        string normalized =
            text.Trim().Replace(',', '.');

        if (!double.TryParse(
                normalized,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double value))
        {
            throw new ArgumentException(
                "Geçerli bir sayısal değer girin.");
        }

        if (double.IsNaN(value) ||
            double.IsInfinity(value))
        {
            throw new ArgumentException(
                "Geçerli bir sayısal değer girin.");
        }

        return value;
    }

    // EN: Updates all LED light layers using the approximate forward-voltage color
    // TR: Tüm LED ışık katmanlarını yaklaşık ileri yön voltajı rengiyle günceller
    private void UpdateLedVisual(
        double ledVoltage)
    {
        Color ledColor =
            GetLedColor(ledVoltage);

        LedImage.Opacity = 1.0;

        LedCore.Fill =
            new SolidColorBrush(
                ledColor);

        LedCore.Opacity = 0.72;

        LedInnerGlow.Fill =
            new SolidColorBrush(
                WithAlpha(
                    ledColor,
                    0.38f));

        LedInnerGlow.Opacity = 0.85;

        LedInnerGlow.Shadow =
            new Shadow
            {
                Brush =
                    new SolidColorBrush(
                        ledColor),

                Radius = 25,
                Opacity = 0.95f,
                Offset = new Point(0, 0)
            };

        LedOuterGlow.Fill =
            new SolidColorBrush(
                WithAlpha(
                    ledColor,
                    0.16f));

        LedOuterGlow.Opacity = 0.65;

        LedOuterGlow.Shadow =
            new Shadow
            {
                Brush =
                    new SolidColorBrush(
                        ledColor),

                Radius = 40,
                Opacity = 0.70f,
                Offset = new Point(0, 0)
            };
    }

    // EN: Returns an approximate visual LED color from its forward voltage
    // TR: İleri yön voltajından yaklaşık görsel LED rengini döndürür
    private static Color GetLedColor(
        double ledVoltage)
    {
        if (ledVoltage < 1.8)
        {
            return Color.FromArgb(
                "#8B0000");
        }

        if (ledVoltage < 2.0)
        {
            return Color.FromArgb(
                "#FF2A2A");
        }

        if (ledVoltage < 2.2)
        {
            return Color.FromArgb(
                "#FF7A1A");
        }

        if (ledVoltage < 2.4)
        {
            return Color.FromArgb(
                "#FFD43B");
        }

        if (ledVoltage < 2.8)
        {
            return Color.FromArgb(
                "#70FF4D");
        }

        if (ledVoltage < 3.0)
        {
            return Color.FromArgb(
                "#00E5C3");
        }

        if (ledVoltage < 3.4)
        {
            return Color.FromArgb(
                "#3D8BFF");
        }

        if (ledVoltage < 3.7)
        {
            return Color.FromArgb(
                "#F4F7FF");
        }

        return Color.FromArgb(
            "#A855F7");
    }

    // EN: Creates a copy of a color with the requested alpha value
    // TR: İstenen alfa değerine sahip renk kopyasını oluşturur
    private static Color WithAlpha(
        Color color,
        float alpha)
    {
        return new Color(
            color.Red,
            color.Green,
            color.Blue,
            alpha);
    }

    // EN: Restores the LED preview to its unlit state
    // TR: LED önizlemesini sönük başlangıç durumuna döndürür
    private void ResetLedVisual()
    {
        LedImage.Opacity = 1.0;

        LedCore.Fill =
            new SolidColorBrush(
                Colors.Transparent);

        LedCore.Opacity = 0;

        LedInnerGlow.Fill =
            new SolidColorBrush(
                Colors.Transparent);

        LedInnerGlow.Opacity = 0;

        LedInnerGlow.Shadow =
            CreateDisabledShadow();

        LedOuterGlow.Fill =
            new SolidColorBrush(
                Colors.Transparent);

        LedOuterGlow.Opacity = 0;

        LedOuterGlow.Shadow =
            CreateDisabledShadow();

        LedCore.Scale = 1.0;
        LedInnerGlow.Scale = 1.0;
        LedOuterGlow.Scale = 1.0;
    }

    // EN: Creates an invisible shadow for the unlit LED state
    // TR: Sönük LED durumu için görünmez gölge oluşturur
    private static Shadow CreateDisabledShadow()
    {
        return new Shadow
        {
            Brush =
                new SolidColorBrush(
                    Colors.Transparent),

            Radius = 0,
            Opacity = 0,
            Offset = new Point(0, 0)
        };
    }

    // EN: Plays a subtle press animation on action buttons
    // TR: İşlem butonlarında hafif basma animasyonu oynatır
    private static async Task AnimateButtonAsync(
        VisualElement element)
    {
        await element.ScaleToAsync(
            0.96,
            70,
            Easing.CubicOut);

        await element.ScaleToAsync(
            1.0,
            90,
            Easing.CubicOut);
    }

    // EN: Animates the result card after calculation
    // TR: Hesaplamadan sonra sonuç kartını hareketlendirir
    private async Task AnimateResultAsync()
    {
        ResultCard.Opacity = 0.72;
        ResultCard.Scale = 0.97;

        Task fadeTask =
            ResultCard.FadeToAsync(
                1.0,
                160,
                Easing.CubicOut);

        Task scaleTask =
            ResultCard.ScaleToAsync(
                1.0,
                160,
                Easing.CubicOut);

        await Task.WhenAll(
            fadeTask,
            scaleTask);
    }

    // EN: Adds a subtle light-up pulse to the LED preview
    // TR: LED önizlemesine hafif yanma darbesi ekler
    private async Task AnimateLedAsync()
    {
        LedCore.Scale = 0.88;
        LedInnerGlow.Scale = 0.88;
        LedOuterGlow.Scale = 0.88;

        Task coreTask =
            LedCore.ScaleToAsync(
                1.0,
                180,
                Easing.CubicOut);

        Task innerTask =
            LedInnerGlow.ScaleToAsync(
                1.0,
                210,
                Easing.CubicOut);

        Task outerTask =
            LedOuterGlow.ScaleToAsync(
                1.0,
                240,
                Easing.CubicOut);

        await Task.WhenAll(
            coreTask,
            innerTask,
            outerTask);
    }

    // EN: Navigates back to the previous page
    // TR: Önceki sayfaya döner
    private async void OnBackTapped(
        object? sender,
        TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}