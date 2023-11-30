namespace TimeBilling.Maui.Views;

using TimeBilling.Maui.ViewModels;

public partial class CustomerPage : ContentPage
{
  public CustomerPage(CustomerPageViewModel vm)
  {
    InitializeComponent();
    BindingContext = vm;
  }
}