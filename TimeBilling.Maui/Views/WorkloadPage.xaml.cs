namespace TimeBilling.Maui.Views;

using TimeBilling.Maui.ViewModels;

public partial class WorkloadPage : ContentPage
{
  public WorkloadPage(WorkloadPageViewModel vm)
  {
    InitializeComponent();
    BindingContext = vm;
  }
}