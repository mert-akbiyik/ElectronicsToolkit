using PCBToolkit.Data;
using PCBToolkit.Models;

namespace PCBToolkit.Views;

public partial class ThtPackageFinderPage : ContentPage
{
    private readonly List<ThtPackage> _packages;

    public ThtPackageFinderPage()
    {
        InitializeComponent();

        _packages =
            ThtPackageData.GetPackages();

        var familyOptions =
            new List<string>
            {
                "Aile seçin"
            };

        familyOptions.AddRange(
            _packages
                .Select(p => p.Family)
                .Distinct());

        FamilyPicker.ItemsSource =
            familyOptions;

        FamilyPicker.SelectedIndex = 0;

        PackagePicker.ItemsSource =
            new List<string>
            {
                "Paket seçin"
            };

        PackagePicker.SelectedIndex = 0;
        PackagePicker.IsEnabled = false;
    }

    // EN: Updates the package list according to the selected package family
    // TR: Seçilen paket ailesine göre paket listesini günceller
    private void OnFamilySelected(
        object? sender,
        EventArgs e)
    {
        if (FamilyPicker.SelectedIndex <= 0)
        {
            PackagePicker.IsEnabled = false;

            ClearPackageDetails();

            return;
        }

        string selectedFamily =
            FamilyPicker.SelectedItem?.ToString()
            ?? string.Empty;

        var packageOptions =
            new List<string>
            {
                "Paket seçin"
            };

        packageOptions.AddRange(
            _packages
                .Where(
                    p => p.Family == selectedFamily)
                .Select(
                    p => p.PackageName));

        PackagePicker.ItemsSource =
            packageOptions;

        PackagePicker.SelectedIndex = 0;
        PackagePicker.IsEnabled = true;

        ClearPackageDetails();
    }

    // EN: Displays the technical information of the selected package
    // TR: Seçilen paketin teknik bilgilerini ekranda gösterir
    private async void OnPackageSelected(
        object? sender,
        EventArgs e)
    {
        if (PackagePicker.SelectedIndex <= 0)
            return;

        string selectedFamily =
            FamilyPicker.SelectedItem?.ToString()
            ?? string.Empty;

        string selectedPackageName =
            PackagePicker.SelectedItem?.ToString()
            ?? string.Empty;

        ThtPackage? selectedPackage =
            _packages.FirstOrDefault(
                p =>
                    p.Family == selectedFamily &&
                    p.PackageName == selectedPackageName);

        if (selectedPackage == null)
            return;

        DescriptionLabel.Text =
            selectedPackage.Description;

        BodySizeLabel.Text =
            selectedPackage.BodySize;

        PinCountLabel.Text =
            selectedPackage.PinCount;

        LeadPitchLabel.Text =
            selectedPackage.LeadPitch;

        DiameterLabel.Text =
            selectedPackage.Diameter;

        MountingLabel.Text =
            selectedPackage.MountingType;

        NoteLabel.Text =
            selectedPackage.Note;

        await AnimateTechnicalInfoAsync();
    }

    // EN: Animates the technical information card after package selection
    // TR: Paket seçiminden sonra teknik bilgi kartını hareketlendirir
    private async Task AnimateTechnicalInfoAsync()
    {
        TechnicalInfoCard.Opacity = 0.72;
        TechnicalInfoCard.Scale = 0.97;

        Task fadeTask =
            TechnicalInfoCard.FadeToAsync(
                1.0,
                160,
                Easing.CubicOut);

        Task scaleTask =
            TechnicalInfoCard.ScaleToAsync(
                1.0,
                160,
                Easing.CubicOut);

        await Task.WhenAll(
            fadeTask,
            scaleTask);
    }

    // EN: Resets the package detail fields to their default state
    // TR: Paket detay alanlarını varsayılan durumuna sıfırlar
    private void ClearPackageDetails()
    {
        DescriptionLabel.Text =
            "Paket seçerek bilgileri görüntüleyebilirsiniz.";

        BodySizeLabel.Text = "—";
        PinCountLabel.Text = "—";
        LeadPitchLabel.Text = "—";
        DiameterLabel.Text = "—";
        MountingLabel.Text = "—";
        NoteLabel.Text = "—";
    }

    // EN: Opens the official Texas Instruments packaging page in the device browser
    // TR: Texas Instruments resmi paket sayfasını cihazın tarayıcısında açar
    private async void OnTexasInstrumentsTapped(
        object? sender,
        TappedEventArgs e)
    {
        await Launcher.Default.OpenAsync(
            "https://www.ti.com/design-development/packaging.html");
    }

    // EN: Opens the official Infineon package page in the device browser
    // TR: Infineon resmi paket sayfasını cihazın tarayıcısında açar
    private async void OnInfineonTapped(
        object? sender,
        TappedEventArgs e)
    {
        await Launcher.Default.OpenAsync(
            "https://www.infineon.com/package-overview");
    }

    // EN: Opens the official onsemi technical documentation page in the device browser
    // TR: onsemi resmi teknik dokümantasyon sayfasını cihazın tarayıcısında açar
    private async void OnOnsemiTapped(
        object? sender,
        TappedEventArgs e)
    {
        await Launcher.Default.OpenAsync(
            "https://www.onsemi.com/design/technical-documentation");
    }

    // EN: Navigates back to the previous page
    // TR: Önceki sayfaya geri döner
    private async void OnBackTapped(
        object? sender,
        TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}