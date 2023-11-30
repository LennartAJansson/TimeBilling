namespace TimeBilling.Maui.Views;

using TimeBilling.Maui.ViewModels;

public partial class CustomersPage : ContentPage
{
  public CustomersPage(CustomersPageViewModel vm)
  {
    InitializeComponent();
    BindingContext = vm;
  }
}