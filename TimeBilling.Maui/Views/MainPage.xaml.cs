namespace TimeBilling.Maui.Views;

using TimeBilling.Maui.ViewModels;
using CommunityToolkit.Maui;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

