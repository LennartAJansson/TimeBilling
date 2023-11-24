namespace TimeBilling.Maui;

using TimeBilling.Maui.Views;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitRoutes();
        InitializeComponent();
    }

    private void InitRoutes()
    {
        Routing.RegisterRoute("People/Person", typeof(PersonPage));
    }
}
