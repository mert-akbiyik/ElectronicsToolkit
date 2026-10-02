namespace PCBToolkit.Views;

public partial class SmdPage : ContentPage
{
    private bool _isNavigating;

    public SmdPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _isNavigating = false;

        ResistorCodeCard.Scale = 1;
        CapacitorCodeCard.Scale = 1;
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

    private async void OnResistorCodeTapped(
        object? sender,
        TappedEventArgs e)
    {
        if (_isNavigating)
            return;

        _isNavigating = true;

        await AnimateCardAsync(
            ResistorCodeCard);

        await Shell.Current.GoToAsync(
            nameof(SmdResistorPage));
    }

    private async void OnCapacitorCodeTapped(
        object? sender,
        TappedEventArgs e)
    {
        if (_isNavigating)
            return;

        _isNavigating = true;

        await AnimateCardAsync(
            CapacitorCodeCard);

        await Shell.Current.GoToAsync(
            nameof(SmdCapacitorPage));
    }

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
            nameof(SmdPackageFinderPage));
    }

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
            nameof(SmdPackageReferencePage));
    }

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