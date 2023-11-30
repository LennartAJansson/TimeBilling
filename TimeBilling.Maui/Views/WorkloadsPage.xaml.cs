namespace TimeBilling.Maui.Views;

using TimeBilling.Maui.ViewModels;

public partial class WorkloadsPage : ContentPage
{
  public WorkloadsPage(WorkloadsPageViewModel vm)
  {
    InitializeComponent();
    BindingContext = vm;
  }
}