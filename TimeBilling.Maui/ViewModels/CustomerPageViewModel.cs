namespace TimeBilling.Maui.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;
using TimeBilling.Maui.Services;

public partial class CustomerPageViewModel : ObservableRecipient, IRecipient<SelectedCustomerChanged>
{
  [ObservableProperty]
  private Customer? selectedCustomer;

  private readonly ICustomerService service;

  public CustomerPageViewModel(ICustomerService service)
  {
    Messenger.RegisterAll(this);
    this.service = service;
  }

  public void Receive(SelectedCustomerChanged message) => SelectedCustomer = message.Value;

  [RelayCommand]
  public void SaveAndExit()
  {
    _ = service.UpdateCustomer(SelectedCustomer);
    RefreshCustomersList message = new(SelectedCustomer);
    _ = WeakReferenceMessenger.Default.Send(message);

    //await ShowToast("Customer saved");

    _ = Shell.Current.Navigation.PopAsync();
    //GoBack();
  }

  [RelayCommand]
  public void GoBack() => Shell.Current.Navigation.PopAsync();
}
