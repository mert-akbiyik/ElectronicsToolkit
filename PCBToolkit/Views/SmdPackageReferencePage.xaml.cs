using PCBToolkit.Data;
using PCBToolkit.Models;

namespace PCBToolkit.Views;

public partial class SmdPackageReferencePage : ContentPage
{
    private readonly List<SmdPackageReference> _packages;

    public SmdPackageReferencePage()
    {
        InitializeComponent();

        _packages =
            SmdPackageReferenceData.GetPackages();

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

        var packageOptions =
            new List<string>
            {
                "Paket seçin"
            };

        PackagePicker.ItemsSource =
            packageOptions;

        PackagePicker.SelectedIndex = 0;
        PackagePicker.IsEnabled = false;
    }

    // EN: Lists the packages belonging to the selected package family
    // TR: Seçilen paket ailesine ait paketleri listeler
    private void OnFamilySelected(
        object? sender,
        EventArgs e)
    {
        // EN: Disables package selection if no valid family is selected
        // TR: Geçerli bir aile seçilmediyse paket seçimini devre dışı bırakır
        if (FamilyPicker.SelectedIndex <= 0)
        {
            PackagePicker.IsEnabled = false;
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
    // TR: Seçilen paketin teknik bilgilerini gösterir
    private async void OnPackageSelected(
        object? sender,
        EventArgs e)
    {
        // EN: Does not process the default package option
        // TR: Varsayılan paket seçeneğinde işlem yapmaz
        if (PackagePicker.SelectedIndex <= 0)
            return;

        string selectedPackageName =
            PackagePicker.SelectedItem?.ToString()
            ?? string.Empty;

        SmdPackageReference? selectedPackage =
            _packages.FirstOrDefault(
                p => p.PackageName ==
                     selectedPackageName);

        if (selectedPackage == null)
            return;

        DescriptionLabel.Text =
            selectedPackage.Description;

        MountingLabel.Text =
            selectedPackage.MountingType;

        PinTypeLabel.Text =
            selectedPackage.PinType;

        PinCountLabel.Text =
            selectedPackage.TypicalPinCount;

        PitchLabel.Text =
            selectedPackage.TypicalPitch;

        UsageLabel.Text =
            selectedPackage.TypicalUsage;

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

    // EN: Resets the package details to their initial state
    // TR: Paket detaylarını başlangıç durumuna döndürür
    private void ClearPackageDetails()
    {
        DescriptionLabel.Text =
            "Paket seçerek bilgileri görüntüleyebilirsiniz.";

        MountingLabel.Text = "—";
        PinTypeLabel.Text = "—";
        PinCountLabel.Text = "—";
        PitchLabel.Text = "—";
        UsageLabel.Text = "—";
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