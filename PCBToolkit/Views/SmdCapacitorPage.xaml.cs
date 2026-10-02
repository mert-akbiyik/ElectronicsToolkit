using PCBToolkit.Services;

namespace PCBToolkit.Views;

public partial class SmdCapacitorPage : ContentPage
{
    private readonly SmdCapacitorService _capacitorService;

    public SmdCapacitorPage()
    {
        InitializeComponent();

        _capacitorService =
            new SmdCapacitorService();
    }

    // EN: Calculates the entered capacitor code
    // TR: Girilen kapasitör kodunu hesaplar
    private async void OnCalculateClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            CalculateButton);

        try
        {
            string code =
                (CapacitorCodeEntry.Text ?? string.Empty)
                .Trim();

            double picofarads =
                _capacitorService
                    .CalculatePicofarads(code);

            double nanofarads =
                picofarads / 1_000;

            double microfarads =
                picofarads / 1_000_000;

            PicofaradResultLabel.Text =
                $"{NumberFormatService.Format(picofarads)} pF";

            NanofaradResultLabel.Text =
                $"{NumberFormatService.Format(nanofarads)} nF";

            MicrofaradResultLabel.Text =
                $"{NumberFormatService.Format(microfarads)} µF";

            BreakdownLabel.Text =
                $"{code} → {code[..2]} × 10^{code[2]} pF";

            await AnimateResultAsync();
        }
        catch (ArgumentException ex)
        {
            ShowError(ex.Message);

            await AnimateResultAsync();
        }
    }

    // EN: Displays invalid code information in the result area
    // TR: Hatalı kod bilgisini sonuç alanında gösterir
    private void ShowError(
        string message)
    {
        PicofaradResultLabel.Text =
            "Hatalı Kod";

        NanofaradResultLabel.Text =
            "— nF";

        MicrofaradResultLabel.Text =
            "— µF";

        BreakdownLabel.Text =
            message;
    }

    // EN: Clears the input and result areas
    // TR: Giriş ve sonuç alanlarını temizler
    private async void OnClearClicked(
        object? sender,
        EventArgs e)
    {
        await AnimateButtonAsync(
            ClearButton);

        CapacitorCodeEntry.Text =
            string.Empty;

        ResetResultArea();

        CapacitorCodeEntry.Focus();
    }

    // EN: Resets the result area to its initial state
    // TR: Sonuç alanını başlangıç durumuna döndürür
    private void ResetResultArea()
    {
        PicofaradResultLabel.Text =
            "— pF";

        NanofaradResultLabel.Text =
            "— nF";

        MicrofaradResultLabel.Text =
            "— µF";

        BreakdownLabel.Text =
            "Kapasitör kodunu girerek hesaplama yapabilirsiniz.";
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

    // EN: Animates the result card after its content changes
    // TR: İçeriği değiştikten sonra sonuç kartını hareketlendirir
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