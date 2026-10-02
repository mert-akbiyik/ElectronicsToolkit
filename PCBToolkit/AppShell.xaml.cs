using PCBToolkit.Views;

namespace PCBToolkit
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SmdPage), typeof(SmdPage));
            Routing.RegisterRoute(nameof(ThtPage), typeof(ThtPage));
            Routing.RegisterRoute(nameof(SmdResistorPage), typeof(SmdResistorPage));
            Routing.RegisterRoute(nameof(SmdCapacitorPage), typeof(SmdCapacitorPage));
            Routing.RegisterRoute(nameof(SmdPackageFinderPage), typeof(SmdPackageFinderPage));
            Routing.RegisterRoute(nameof(SmdPackageReferencePage), typeof(SmdPackageReferencePage));
            Routing.RegisterRoute(nameof(ThtResistorPage),typeof(ThtResistorPage));
            Routing.RegisterRoute(nameof(ThtLedResistorPage),typeof (ThtLedResistorPage));
            Routing.RegisterRoute(nameof(ThtPackageFinderPage), typeof(ThtPackageFinderPage));
            Routing.RegisterRoute(nameof(ThtPackageReferencePage), typeof(ThtPackageReferencePage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        }
    }
}