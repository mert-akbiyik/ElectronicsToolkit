using PCBToolkit.Services;

namespace PCBToolkit.Views;

public partial class ThtResistorPage : ContentPage
{
    private readonly ThtResistorService _resistorService;

    private int _bandCount = 4;

    private readonly List<string> _digitColors =
    [
        "Siyah",
        "Kahverengi",
        "Kırmızı",
        "Turuncu",
        "Sarı",
        "Yeşil",
        "Mavi",
        "Mor",
        "Gri",
        "Beyaz"
    ];

    private readonly List<string> _multiplierColors =
    [
        "Siyah",
        "Kahverengi",
        "Kırmızı",
        "Turuncu",
        "Sarı",
        "Yeşil",
        "Mavi",
        "Mor",
        "Gri",
        "Beyaz",
        "Altın",
        "Gümüş"
    ];

    private readonly List<string> _toleranceColors =
    [
        "Kahverengi",
        "Kırmızı",
        "Yeşil",
        "Mavi",
        "Mor",
        "Gri",
        "Altın",
        "Gümüş",
        "Renksiz"
    ];

    private readonly List<string> _tcrColors =
    [
        "Kahverengi",
        "Kırmızı",
        "Turuncu",
        "Sarı",
        "Mavi",
        "Mor"
    ];

    public ThtResistorPage()
    {
        InitializeComponent();

        _resistorService =
            new ThtResistorService();

        LoadPickers();
        SetBandMode(4);
    }

    // EN: Loads the available resistor colors into the pickers
    // TR: Kullanılabilir direnç renklerini seçim alanlarına yükler
    private void LoadPickers()
    {
        Band1Picker.ItemsSource = _digitColors;
        Band2Picker.ItemsSource = _digitColors;
        Band3Picker.ItemsSource = _digitColors;

        MultiplierPicker.ItemsSource =
            _multiplierColors;

        TolerancePicker.ItemsSource =
            _toleranceColors;

        TcrPicker.ItemsSource =
            _tcrColors;
    }

    // EN: Activates four-band resistor mode
    // TR: Dört bant direnç modunu etkinleştirir
    private async void OnFourBandClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            FourBandButton);

        SetBandMode(4);
    }

    // EN: Activates five-band resistor mode
    // TR: Beş bant direnç modunu etkinleştirir
    private async void OnFiveBandClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            FiveBandButton);

        SetBandMode(5);
    }

    // EN: Activates six-band resistor mode
    // TR: Altı bant direnç modunu etkinleştirir
    private async void OnSixBandClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            SixBandButton);

        SetBandMode(6);
    }

    // EN: Updates the interface for the selected resistor band count
    // TR: Seçilen direnç bant sayısına göre arayüzü günceller
    private void SetBandMode(
        int bandCount)
    {
        _bandCount = bandCount;

        Band3Picker.IsVisible =
            bandCount >= 5;

        TcrPicker.IsVisible =
            bandCount == 6;

        TcrResultLabel.IsVisible =
            bandCount == 6;

        FourBandVisual.IsVisible =
            bandCount == 4;

        FiveBandVisual.IsVisible =
            bandCount == 5;

        SixBandVisual.IsVisible =
            bandCount == 6;

        FourBandButton.BackgroundColor =
            bandCount == 4
                ? Color.FromArgb("#FF8A3D")
                : Color.FromArgb("#18232C");

        FiveBandButton.BackgroundColor =
            bandCount == 5
                ? Color.FromArgb("#FF8A3D")
                : Color.FromArgb("#18232C");

        SixBandButton.BackgroundColor =
            bandCount == 6
                ? Color.FromArgb("#FF8A3D")
                : Color.FromArgb("#18232C");

        FourBandButton.TextColor =
            bandCount == 4
                ? Colors.White
                : Color.FromArgb("#AAB6C0");

        FiveBandButton.TextColor =
            bandCount == 5
                ? Colors.White
                : Color.FromArgb("#AAB6C0");

        SixBandButton.TextColor =
            bandCount == 6
                ? Colors.White
                : Color.FromArgb("#AAB6C0");

        ClearSelections();
    }

    // EN: Updates the resistor preview whenever a color selection changes
    // TR: Renk seçimi değiştiğinde direnç önizlemesini günceller
    private void OnBandSelectionChanged(
        object? sender,
        EventArgs e)
    {
        UpdateResistorVisual();
    }

    // EN: Applies the selected colors to the visible resistor bands
    // TR: Seçilen renkleri görünür direnç bantlarına uygular
    private void UpdateResistorVisual()
    {
        Color band1Color =
            GetVisualColor(
                Band1Picker.SelectedItem as string);

        Color band2Color =
            GetVisualColor(
                Band2Picker.SelectedItem as string);

        Color band3Color =
            GetVisualColor(
                Band3Picker.SelectedItem as string);

        Color multiplierColor =
            GetVisualColor(
                MultiplierPicker.SelectedItem as string);

        Color toleranceColor =
            GetVisualColor(
                TolerancePicker.SelectedItem as string);

        Color tcrColor =
            GetVisualColor(
                TcrPicker.SelectedItem as string);

        if (_bandCount == 4)
        {
            FourBand1.Color = band1Color;
            FourBand2.Color = band2Color;
            FourMultiplierBand.Color = multiplierColor;
            FourToleranceBand.Color = toleranceColor;

            return;
        }

        if (_bandCount == 5)
        {
            FiveBand1.Color = band1Color;
            FiveBand2.Color = band2Color;
            FiveBand3.Color = band3Color;
            FiveMultiplierBand.Color = multiplierColor;
            FiveToleranceBand.Color = toleranceColor;

            return;
        }

        SixBand1.Color = band1Color;
        SixBand2.Color = band2Color;
        SixBand3.Color = band3Color;
        SixMultiplierBand.Color = multiplierColor;
        SixToleranceBand.Color = toleranceColor;
        SixTcrBand.Color = tcrColor;
    }

    // EN: Converts a resistor color name to its visual MAUI color
    // TR: Direnç renk adını görsel MAUI rengine dönüştürür
    private static Color GetVisualColor(
        string? colorName)
    {
        return colorName switch
        {
            "Siyah" =>
                Color.FromArgb("#111111"),

            "Kahverengi" =>
                Color.FromArgb("#6B3E26"),

            "Kırmızı" =>
                Color.FromArgb("#E53935"),

            "Turuncu" =>
                Color.FromArgb("#F57C00"),

            "Sarı" =>
                Color.FromArgb("#FDD835"),

            "Yeşil" =>
                Color.FromArgb("#2E7D32"),

            "Mavi" =>
                Color.FromArgb("#1565C0"),

            "Mor" =>
                Color.FromArgb("#7B1FA2"),

            "Gri" =>
                Color.FromArgb("#808080"),

            "Beyaz" =>
                Color.FromArgb("#F5F5F5"),

            "Altın" =>
                Color.FromArgb("#D4AF37"),

            "Gümüş" =>
                Color.FromArgb("#C0C0C0"),

            "Renksiz" =>
                Color.FromArgb("#D9B77F"),

            _ =>
                Colors.Transparent
        };
    }

    // EN: Calculates the resistor value from the selected bands
    // TR: Seçilen bantlardan direnç değerini hesaplar
    private async void OnCalculateClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            CalculateButton);

        try
        {
            string band1 =
                GetSelectedColor(
                    Band1Picker);

            string band2 =
                GetSelectedColor(
                    Band2Picker);

            string multiplier =
                GetSelectedColor(
                    MultiplierPicker);

            string tolerance =
                GetSelectedColor(
                    TolerancePicker);

            double resistance;

            if (_bandCount == 4)
            {
                resistance =
                    _resistorService.Calculate4Band(
                        band1,
                        band2,
                        multiplier);
            }
            else
            {
                string band3 =
                    GetSelectedColor(
                        Band3Picker);

                resistance =
                    _resistorService.Calculate5Or6Band(
                        band1,
                        band2,
                        band3,
                        multiplier);
            }

            double toleranceValue =
                _resistorService.GetTolerance(
                    tolerance);

            ResistanceResultLabel.Text =
                FormatResistance(
                    resistance);

            ToleranceResultLabel.Text =
                $"Tolerans: ±{NumberFormatService.Format(toleranceValue)}%";

            if (_bandCount == 6)
            {
                string tcr =
                    GetSelectedColor(
                        TcrPicker);

                int tcrValue =
                    _resistorService
                        .GetTemperatureCoefficient(tcr);

                TcrResultLabel.Text =
                    $"TCR: {tcrValue} ppm/°C";
            }

            await AnimateResultAsync();
        }
        catch (ArgumentException ex)
        {
            ResistanceResultLabel.Text =
                "Eksik / Hatalı Seçim";

            ToleranceResultLabel.Text =
                ex.Message;

            if (_bandCount == 6)
            {
                TcrResultLabel.Text =
                    "TCR: —";
            }

            await AnimateResultAsync();
        }
    }

    // EN: Clears all resistor selections and preview bands
    // TR: Tüm direnç seçimlerini ve önizleme bantlarını temizler
    private async void OnClearClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            ClearButton);

        ClearSelections();
    }

    // EN: Restores all selections and results to their initial state
    // TR: Tüm seçimleri ve sonuçları başlangıç durumuna döndürür
    private void ClearSelections()
    {
        Band1Picker.SelectedIndex = -1;
        Band2Picker.SelectedIndex = -1;
        Band3Picker.SelectedIndex = -1;

        MultiplierPicker.SelectedIndex = -1;
        TolerancePicker.SelectedIndex = -1;
        TcrPicker.SelectedIndex = -1;

        ResistanceResultLabel.Text = "—";
        ToleranceResultLabel.Text = "Tolerans: —";
        TcrResultLabel.Text = "TCR: —";

        ResetResistorVisual();
    }

    // EN: Clears every visual resistor band
    // TR: Tüm görsel direnç bantlarını temizler
    private void ResetResistorVisual()
    {
        FourBand1.Color = Colors.Transparent;
        FourBand2.Color = Colors.Transparent;
        FourMultiplierBand.Color = Colors.Transparent;
        FourToleranceBand.Color = Colors.Transparent;

        FiveBand1.Color = Colors.Transparent;
        FiveBand2.Color = Colors.Transparent;
        FiveBand3.Color = Colors.Transparent;
        FiveMultiplierBand.Color = Colors.Transparent;
        FiveToleranceBand.Color = Colors.Transparent;

        SixBand1.Color = Colors.Transparent;
        SixBand2.Color = Colors.Transparent;
        SixBand3.Color = Colors.Transparent;
        SixMultiplierBand.Color = Colors.Transparent;
        SixToleranceBand.Color = Colors.Transparent;
        SixTcrBand.Color = Colors.Transparent;
    }

    // EN: Returns the selected resistor color
    // TR: Seçilen direnç rengini döndürür
    private static string GetSelectedColor(
        Picker picker)
    {
        if (picker.SelectedItem is not string color)
        {
            throw new ArgumentException(
                "Tüm gerekli renk bantlarını seçin.");
        }

        return color;
    }

    // EN: Formats resistance using Ω, kΩ or MΩ
    // TR: Direnç değerini Ω, kΩ veya MΩ kullanarak biçimlendirir
    private static string FormatResistance(
        double resistance)
    {
        if (resistance >= 1_000_000)
        {
            return
                $"{NumberFormatService.Format(resistance / 1_000_000)} MΩ";
        }

        if (resistance >= 1_000)
        {
            return
                $"{NumberFormatService.Format(resistance / 1_000)} kΩ";
        }

        return
            $"{NumberFormatService.Format(resistance)} Ω";
    }

    // EN: Plays a subtle press animation on interactive buttons
    // TR: Etkileşimli butonlarda hafif basma animasyonu oynatır
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

    // EN: Animates the result card after the result changes
    // TR: Sonuç değiştikten sonra sonuç kartını hareketlendirir
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

    // EN: Navigates back to the previous page
    // TR: Önceki sayfaya döner
    private async void OnBackTapped(
        object? sender,
        TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}