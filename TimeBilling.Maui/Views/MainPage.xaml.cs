namespace TimeBilling.Maui.Views;

using TimeBilling.Maui.ViewModels;

public partial class MainPage : ContentPage
{
  public MainPage(MainPageViewModel vm)
  {
    InitializeComponent();
    BindingContext = vm;
  }
}

