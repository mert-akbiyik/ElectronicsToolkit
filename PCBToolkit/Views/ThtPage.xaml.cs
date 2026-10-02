namespace PCBToolkit.Views;

public partial class ThtPage : ContentPage
{
    private bool _isNavigating;

    public ThtPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _isNavigating = false;

        ResistorColorCard.Scale = 1;
        LedResistorCard.Scale = 1;
        PackageFinderCard.Scale = 1;
        PackageReferenceCard.Scale = 1;
    }

    // EN: Plays a subtle press animation before navigation
    // TR: Navigasyondan önce hafif basma animasyonu oynatır
    private static async Task AnimateCardAsync(VisualElement card)
    {
        await card.ScaleToAsync(
            0.97,
            80,
            Easing.CubicOut);

        await card.ScaleToAsync(
            1.0,
            100,
            Easing.CubicOut);
    }

    // EN: Navigates to the THT resistor color code page
    // TR: THT direnç renk kodu sayfasına gider
    private async void OnResistorColorTapped(
        object? sender,
        TappedEventArgs e)
    {
        if (_isNavigating)
            return;

        _isNavigating = true;

        await AnimateCardAsync(
            ResistorColorCard);

        await Shell.Current.GoToAsync(
            nameof(ThtResistorPage));
    }

    // EN: Navigates to the LED series resistor page
    // TR: LED seri direnç sayfasına gider
    private async void OnLedResistorTapped(
        object? sender,
        TappedEventArgs e)
    {
        if (_isNavigating)
            return;

        _isNavigating = true;

        await AnimateCardAsync(
            LedResistorCard);

        await Shell.Current.GoToAsync(
            nameof(ThtLedResistorPage));
    }

    // EN: Navigates to the THT package finder page
    // TR: THT paket bulucu sayfasına gider
    private async void OnPackageFinderTapped(
        object? sender,
        TappedEventArgs e)
    {
        if (_isNavigating)
            return;

        _isNavigating = true;

        await AnimateCardAsync(
            PackageFinderCard);

        await Shell.Current.GoToAsync(
            nameof(ThtPackageFinderPage));
    }

    // EN: Navigates to the THT package reference page
    // TR: THT paket referansı sayfasına gider
    private async void OnPackageReferenceTapped(
        object? sender,
        TappedEventArgs e)
    {
        if (_isNavigating)
            return;

        _isNavigating = true;

        await AnimateCardAsync(
            PackageReferenceCard);

        await Shell.Current.GoToAsync(
            nameof(ThtPackageReferencePage));
    }

    // EN: Navigates back to the previous page
    // TR: Önceki sayfaya döner
    private async void OnBackTapped(
        object? sender,
        TappedEventArgs e)
    {
        if (_isNavigating)
            return;

        _isNavigating = true;

        await Shell.Current.GoToAsync("..");
    }
}