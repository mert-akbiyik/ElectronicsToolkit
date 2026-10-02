using PCBToolkit.Data;
using PCBToolkit.Models;

namespace PCBToolkit.Views;

public partial class SmdPackageFinderPage : ContentPage
{
    private readonly List<SmdPackage> _packages;

    public SmdPackageFinderPage()
    {
        InitializeComponent();

        _packages =
            SmdPackageData.GetPackages();

        var packageOptions =
            new List<string>
            {
                "Paket seçin"
            };

        packageOptions.AddRange(
            _packages.Select(
                p => p.ImperialCode));

        PackagePicker.ItemsSource =
            packageOptions;

        // EN: Displays the default package option initially
        // TR: Başlangıçta varsayılan paket seçeneğini gösterir
        PackagePicker.SelectedIndex = 0;
    }

    // EN: Displays the technical information of the selected SMD package
    // TR: Seçilen SMD paketin teknik bilgilerini gösterir
    private async void OnPackageSelected(
        object? sender,
        EventArgs e)
    {
        // EN: Does not process the default package option
        // TR: Varsayılan "Paket seçin" seçeneğinde işlem yapmaz
        if (PackagePicker.SelectedIndex <= 0)
            return;

        string selectedCode =
            PackagePicker.SelectedItem?.ToString()
            ?? string.Empty;

        SmdPackage? selectedPackage =
            _packages.FirstOrDefault(
                p => p.ImperialCode == selectedCode);

        if (selectedPackage == null)
            return;

        ImperialLabel.Text =
            selectedPackage.ImperialCode;

        MetricLabel.Text =
            selectedPackage.MetricCode;

        LengthLabel.Text =
            $"{selectedPackage.LengthMm:G} mm";

        WidthLabel.Text =
            $"{selectedPackage.WidthMm:G} mm";

        DescriptionLabel.Text =
            selectedPackage.Description;

        await AnimatePackageInfoAsync();
    }

    // EN: Animates the package information card after selection
    // TR: Paket seçiminden sonra bilgi kartını hareketlendirir
    private async Task AnimatePackageInfoAsync()
    {
        PackageInfoCard.Opacity = 0.72;
        PackageInfoCard.Scale = 0.97;

        Task fadeTask =
            PackageInfoCard.FadeToAsync(
                1.0,
                160,
                Easing.CubicOut);

        Task scaleTask =
            PackageInfoCard.ScaleToAsync(
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