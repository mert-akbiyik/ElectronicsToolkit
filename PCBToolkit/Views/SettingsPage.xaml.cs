namespace PCBToolkit.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();

        LoadSettings();
        LoadAppInfo();
    }

    private void LoadSettings()
    {
        bool hapticEnabled =
            Preferences.Default.Get("HapticEnabled", true);

        string decimalFormat =
            Preferences.Default.Get("DecimalFormat", "Virgül");

        HapticSwitch.IsToggled = hapticEnabled;

        DecimalPicker.SelectedIndex =
            decimalFormat == "Nokta" ? 1 : 0;
    }

    private void LoadAppInfo()
    {
        VersionLabel.Text =
            $"Sürüm: {AppInfo.Current.VersionString}";
    }

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void OnHapticToggled(object? sender, ToggledEventArgs e)
    {
        Preferences.Default.Set("HapticEnabled", e.Value);
    }

    private void OnDecimalChanged(object? sender, EventArgs e)
    {
        if (DecimalPicker.SelectedIndex < 0)
            return;

        string decimalFormat =
            DecimalPicker.SelectedIndex == 1
                ? "Nokta"
                : "Virgül";

        Preferences.Default.Set("DecimalFormat", decimalFormat);
    }

    private async void OnGitHubClicked(object? sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync(
            "https://github.com/mert-akbiyik");
    }

    private async void OnLinkedInClicked(object? sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync(
            "https://www.linkedin.com/in/mert-akbiyik");
    }
}