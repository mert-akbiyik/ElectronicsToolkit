using PCBToolkit.Services;

namespace PCBToolkit.Views;

public partial class SmdResistorPage : ContentPage
{
    private readonly SmdResistorService _resistorService;

    private enum ResistorCodeType
    {
        Standard,
        RCode,
        Eia96
    }

    private ResistorCodeType _selectedCodeType =
        ResistorCodeType.Standard;

    public SmdResistorPage()
    {
        InitializeComponent();

        _resistorService =
            new SmdResistorService();

        UpdateSelectedCodeTypeUI();
        ResetResultArea();
    }

    // EN: Standard 3 / 4 digit code selection
    // TR: 3 / 4 haneli standart kod seçimi
    private async void OnStandardCodeClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            StandardCodeButton);

        _selectedCodeType =
            ResistorCodeType.Standard;

        ResistorCodeEntry.Placeholder =
            "Örn: 103, 472, 1001";

        UpdateSelectedCodeTypeUI();
        ResetResultArea();
    }

    // EN: R code selection
    // TR: R kodu seçimi
    private async void OnRCodeClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            RCodeButton);

        _selectedCodeType =
            ResistorCodeType.RCode;

        ResistorCodeEntry.Placeholder =
            "Örn: 4R7, R47, 47R";

        UpdateSelectedCodeTypeUI();
        ResetResultArea();
    }

    // EN: EIA-96 code selection
    // TR: EIA-96 kodu seçimi
    private async void OnEia96Clicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            Eia96Button);

        _selectedCodeType =
            ResistorCodeType.Eia96;

        ResistorCodeEntry.Placeholder =
            "Örn: 01A, 01C, 68X";

        UpdateSelectedCodeTypeUI();
        ResetResultArea();
    }

    // EN: Updates the selected code type button appearance
    // TR: Seçili kod türünün buton görünümünü günceller
    private void UpdateSelectedCodeTypeUI()
    {
        SetButtonInactive(
            StandardCodeButton);

        SetButtonInactive(
            RCodeButton);

        SetButtonInactive(
            Eia96Button);

        switch (_selectedCodeType)
        {
            case ResistorCodeType.Standard:
                SetButtonActive(
                    StandardCodeButton);
                break;

            case ResistorCodeType.RCode:
                SetButtonActive(
                    RCodeButton);
                break;

            case ResistorCodeType.Eia96:
                SetButtonActive(
                    Eia96Button);
                break;
        }
    }

    // EN: Applies the active button appearance
    // TR: Butonu aktif görünümüne getirir
    private static void SetButtonActive(
        Button button)
    {
        button.BackgroundColor =
            Color.FromArgb("#102536");

        button.TextColor =
            Color.FromArgb("#4DB8FF");

        button.BorderColor =
            Color.FromArgb("#168BD2");
    }

    // EN: Applies the inactive button appearance
    // TR: Butonu pasif görünümüne getirir
    private static void SetButtonInactive(
        Button button)
    {
        button.BackgroundColor =
            Color.FromArgb("#101820");

        button.TextColor =
            Color.FromArgb("#AAB6C0");

        button.BorderColor =
            Colors.Transparent;
    }

    // EN: Calculates the entered resistor code
    // TR: Girilen direnç kodunu hesaplar
    private async void OnCalculateClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            CalculateButton);

        try
        {
            string code =
                (ResistorCodeEntry.Text ?? string.Empty)
                .Trim()
                .ToUpperInvariant();

            double resistance;

            switch (_selectedCodeType)
            {
                case ResistorCodeType.Standard:
                    resistance =
                        _resistorService
                            .CalculateStandardCode(code);

                    ShowStandardCodeDetails(
                        code,
                        resistance);

                    break;

                case ResistorCodeType.RCode:
                    resistance =
                        _resistorService
                            .CalculateRCode(code);

                    ShowRCodeDetails(
                        code,
                        resistance);

                    break;

                case ResistorCodeType.Eia96:
                    resistance =
                        _resistorService
                            .CalculateEia96(code);

                    ShowEia96Details(
                        code,
                        resistance);

                    break;

                default:
                    throw new ArgumentException(
                        "Geçersiz kod türü.");
            }

            ResultLabel.Text =
                FormatResistance(resistance);

            await AnimateResultAsync();
        }
        catch (ArgumentException ex)
        {
            ShowError(ex.Message);

            await AnimateResultAsync();
        }
    }

    // EN: Displays standard 3 / 4 digit code details
    // TR: 3 / 4 haneli standart kodun detaylarını gösterir
    private void ShowStandardCodeDetails(
        string code,
        double resistance)
    {
        if (code.Length != 3 &&
            code.Length != 4)
        {
            throw new ArgumentException(
                "Standart direnç kodu 3 veya 4 haneli olmalıdır.");
        }

        int significantDigitCount =
            code.Length - 1;

        string significantPart =
            code[..significantDigitCount];

        char multiplierCharacter =
            code[^1];

        if (!int.TryParse(
                significantPart,
                out int significantValue) ||
            !char.IsDigit(
                multiplierCharacter))
        {
            throw new ArgumentException(
                "Standart direnç kodu yalnızca rakamlardan oluşmalıdır.");
        }

        int exponent =
            multiplierCharacter - '0';

        double multiplier =
            Math.Pow(
                10,
                exponent);

        CodeDetailLabel.Text =
            code;

        BaseTitleLabel.Text =
            "Temel Değer";

        BaseValueLabel.Text =
            significantValue.ToString();

        RuleTitleLabel.Text =
            "Çarpan";

        RuleValueLabel.Text =
            $"10{ToSuperscript(exponent)} = ×{NumberFormatService.Format(multiplier)}";

        CalculationDetailLabel.Text =
            $"{significantValue} × " +
            $"{NumberFormatService.Format(multiplier)} = " +
            $"{NumberFormatService.Format(resistance)} Ω";
    }

    // EN: Displays R code details
    // TR: R kodunun detaylarını gösterir
    private void ShowRCodeDetails(
        string code,
        double resistance)
    {
        int rIndex =
            code.IndexOf('R');

        if (rIndex < 0)
        {
            throw new ArgumentException(
                "R kodu içerisinde R karakteri bulunmalıdır.");
        }

        string integerPart =
            code[..rIndex];

        string decimalPart =
            code[(rIndex + 1)..];

        if (integerPart.Length == 0)
        {
            integerPart = "0";
        }

        if (decimalPart.Length == 0)
        {
            decimalPart = "0";
        }

        CodeDetailLabel.Text =
            code;

        BaseTitleLabel.Text =
            "R Kuralı";

        BaseValueLabel.Text =
            "R = ondalık ayırıcı";

        RuleTitleLabel.Text =
            "Değer";

        RuleValueLabel.Text =
            $"{integerPart}.{decimalPart} Ω";

        CalculationDetailLabel.Text =
            $"{code} = {NumberFormatService.Format(resistance)} Ω";
    }

    // EN: Displays EIA-96 code details
    // TR: EIA-96 kodunun detaylarını gösterir
    private void ShowEia96Details(
        string code,
        double resistance)
    {
        if (code.Length != 3)
        {
            throw new ArgumentException(
                "EIA-96 kodu iki rakam ve bir harften oluşmalıdır.");
        }

        string indexPart =
            code[..2];

        char multiplierCode =
            code[2];

        if (!int.TryParse(
                indexPart,
                out int index) ||
            index < 1 ||
            index > 96)
        {
            throw new ArgumentException(
                "EIA-96 kodunun ilk iki hanesi 01 ile 96 arasında olmalıdır.");
        }

        double baseValue =
            GetEia96BaseValue(index);

        double multiplier =
            GetEia96Multiplier(
                multiplierCode);

        CodeDetailLabel.Text =
            code;

        BaseTitleLabel.Text =
            "E96 Kodu";

        BaseValueLabel.Text =
            $"{indexPart} → {NumberFormatService.Format(baseValue)}";

        RuleTitleLabel.Text =
            "Çarpan";

        RuleValueLabel.Text =
            $"{multiplierCode} → ×{NumberFormatService.Format(multiplier)}";

        CalculationDetailLabel.Text =
            $"{NumberFormatService.Format(baseValue)} × " +
            $"{NumberFormatService.Format(multiplier)} = " +
            $"{NumberFormatService.Format(resistance)} Ω";
    }

    // EN: Converts an EIA-96 index to its base E96 value
    // TR: EIA-96 sıra numarasını temel E96 değerine dönüştürür
    private static double GetEia96BaseValue(
        int index)
    {
        int[] e96Values =
        {
            100, 102, 105, 107, 110, 113, 115, 118,
            121, 124, 127, 130, 133, 137, 140, 143,
            147, 150, 154, 158, 162, 165, 169, 174,
            178, 182, 187, 191, 196, 200, 205, 210,
            215, 221, 226, 232, 237, 243, 249, 255,
            261, 267, 274, 280, 287, 294, 301, 309,
            316, 324, 332, 340, 348, 357, 365, 374,
            383, 392, 402, 412, 422, 432, 442, 453,
            464, 475, 487, 499, 511, 523, 536, 549,
            562, 576, 590, 604, 619, 634, 649, 665,
            681, 698, 715, 732, 750, 768, 787, 806,
            825, 845, 866, 887, 909, 931, 953, 976
        };

        return e96Values[index - 1];
    }

    // EN: Converts an EIA-96 letter code to its multiplier
    // TR: EIA-96 harf kodunu çarpana dönüştürür
    private static double GetEia96Multiplier(
        char code)
    {
        return code switch
        {
            'Z' => 0.001,
            'Y' => 0.01,
            'R' => 0.01,
            'X' => 0.1,
            'S' => 0.1,
            'A' => 1,
            'B' => 10,
            'H' => 10,
            'C' => 100,
            'D' => 1_000,
            'E' => 10_000,
            'F' => 100_000,

            _ => throw new ArgumentException(
                "Geçersiz EIA-96 çarpan harfi.")
        };
    }

    // EN: Formats resistance using the appropriate unit
    // TR: Direnç değerini uygun birimle gösterir
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

    // EN: Converts an exponent to superscript characters
    // TR: Üs değerini üst simge karakterlerine dönüştürür
    private static string ToSuperscript(
        int value)
    {
        return value
            .ToString()
            .Replace("0", "⁰")
            .Replace("1", "¹")
            .Replace("2", "²")
            .Replace("3", "³")
            .Replace("4", "⁴")
            .Replace("5", "⁵")
            .Replace("6", "⁶")
            .Replace("7", "⁷")
            .Replace("8", "⁸")
            .Replace("9", "⁹");
    }

    // EN: Displays error information in the result area
    // TR: Hata bilgisini sonuç alanında gösterir
    private void ShowError(
        string message)
    {
        ResultLabel.Text =
            "Hatalı Kod";

        CodeDetailLabel.Text =
            "—";

        BaseTitleLabel.Text =
            "Bilgi";

        BaseValueLabel.Text =
            "—";

        RuleTitleLabel.Text =
            "Kural";

        RuleValueLabel.Text =
            "—";

        CalculationDetailLabel.Text =
            message;
    }

    // EN: Resets the result area to its initial state
    // TR: Sonuç alanını başlangıç durumuna döndürür
    private void ResetResultArea()
    {
        ResultLabel.Text =
            "—";

        CodeDetailLabel.Text =
            "—";

        switch (_selectedCodeType)
        {
            case ResistorCodeType.Standard:
                BaseTitleLabel.Text =
                    "Temel Değer";

                RuleTitleLabel.Text =
                    "Çarpan";
                break;

            case ResistorCodeType.RCode:
                BaseTitleLabel.Text =
                    "R Kuralı";

                RuleTitleLabel.Text =
                    "Değer";
                break;

            case ResistorCodeType.Eia96:
                BaseTitleLabel.Text =
                    "E96 Kodu";

                RuleTitleLabel.Text =
                    "Çarpan";
                break;
        }

        BaseValueLabel.Text =
            "—";

        RuleValueLabel.Text =
            "—";

        CalculationDetailLabel.Text =
            "Direnç kodunu girerek hesaplama yapabilirsiniz.";
    }

    // EN: Clears the input and result areas
    // TR: Giriş ve sonuç alanlarını temizler
    private async void OnClearClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            ClearButton);

        ResistorCodeEntry.Text =
            string.Empty;

        ResetResultArea();

        ResistorCodeEntry.Focus();
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