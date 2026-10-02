using PCBToolkit.Data;
using PCBToolkit.Models;

namespace PCBToolkit.Views;

public partial class ThtPackageReferencePage : ContentPage
{
    private readonly List<ThtPackageReference> _references;

    public ThtPackageReferencePage()
    {
        InitializeComponent();

        _references =
            ThtPackageReferenceData.GetReferences();

        var families =
            new List<string>
            {
                "Aile seçin"
            };

        families.AddRange(
            _references
                .Select(x => x.Family)
                .Distinct());

        FamilyPicker.ItemsSource =
            families;

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

        var packages =
            new List<string>
            {
                "Paket seçin"
            };

        packages.AddRange(
            _references
                .Where(
                    x => x.Family == selectedFamily)
                .Select(
                    x => x.PackageName));

        PackagePicker.ItemsSource =
            packages;

        PackagePicker.SelectedIndex = 0;
        PackagePicker.IsEnabled = true;

        ClearPackageDetails();
    }

    // EN: Displays the reference information of the selected THT package
    // TR: Seçilen THT paketinin referans bilgilerini ekranda gösterir
    private async void OnPackageSelected(
        object? sender,
        EventArgs e)
    {
        if (PackagePicker.SelectedIndex <= 0)
            return;

        string selectedFamily =
            FamilyPicker.SelectedItem?.ToString()
            ?? string.Empty;

        string selectedPackage =
            PackagePicker.SelectedItem?.ToString()
            ?? string.Empty;

        ThtPackageReference? reference =
            _references.FirstOrDefault(
                x =>
                    x.Family == selectedFamily &&
                    x.PackageName == selectedPackage);

        if (reference == null)
            return;

        DescriptionLabel.Text =
            reference.Description;

        MountingLabel.Text =
            reference.MountingType;

        PinCountLabel.Text =
            reference.PinCount;

        LeadPitchLabel.Text =
            reference.LeadPitch;

        BodyTypeLabel.Text =
            reference.BodyType;

        TypicalUsageLabel.Text =
            reference.TypicalUsage;

        NoteLabel.Text =
            reference.Note;

        await AnimatePackageDetailsAsync();
    }

    // EN: Animates all package detail cards after package selection
    // TR: Paket seçiminden sonra tüm paket detay kartlarını hareketlendirir
    private async Task AnimatePackageDetailsAsync()
    {
        TechnicalInfoCard.Opacity = 0.72;
        TechnicalInfoCard.Scale = 0.97;

        TypicalUsageCard.Opacity = 0.72;
        TypicalUsageCard.Scale = 0.97;

        TechnicalNoteCard.Opacity = 0.72;
        TechnicalNoteCard.Scale = 0.97;

        await Task.WhenAll(
            TechnicalInfoCard.FadeToAsync(
                1.0,
                160,
                Easing.CubicOut),

            TechnicalInfoCard.ScaleToAsync(
                1.0,
                160,
                Easing.CubicOut),

            TypicalUsageCard.FadeToAsync(
                1.0,
                180,
                Easing.CubicOut),

            TypicalUsageCard.ScaleToAsync(
                1.0,
                180,
                Easing.CubicOut),

            TechnicalNoteCard.FadeToAsync(
                1.0,
                200,
                Easing.CubicOut),

            TechnicalNoteCard.ScaleToAsync(
                1.0,
                200,
                Easing.CubicOut));
    }

    // EN: Resets the package detail fields to their default state
    // TR: Paket detay alanlarını varsayılan durumuna sıfırlar
    private void ClearPackageDetails()
    {
        DescriptionLabel.Text =
            "Paket seçerek bilgileri görüntüleyebilirsiniz.";

        MountingLabel.Text = "—";
        PinCountLabel.Text = "—";
        LeadPitchLabel.Text = "—";
        BodyTypeLabel.Text = "—";
        TypicalUsageLabel.Text = "—";
        NoteLabel.Text = "—";
    }

    // EN: Opens the official Texas Instruments packaging page in the device browser
    // TR: Texas Instruments resmî paket sayfasını cihazın tarayıcısında açar
    private async void OnTexasInstrumentsTapped(
        object? sender,
        TappedEventArgs e)
    {
        await Launcher.Default.OpenAsync(
            "https://www.ti.com/design-development/packaging.html");
    }

    // EN: Opens the official Infineon package page in the device browser
    // TR: Infineon resmî paket sayfasını cihazın tarayıcısında açar
    private async void OnInfineonTapped(
        object? sender,
        TappedEventArgs e)
    {
        await Launcher.Default.OpenAsync(
            "https://www.infineon.com/package-overview");
    }

    // EN: Opens the official onsemi technical documentation page in the device browser
    // TR: onsemi resmî teknik dokümantasyon sayfasını cihazın tarayıcısında açar
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