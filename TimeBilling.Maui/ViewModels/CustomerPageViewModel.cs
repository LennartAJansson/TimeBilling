namespace TimeBilling.Maui.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;
using TimeBilling.Maui.Services;

public partial class CustomerPageViewModel : ObservableRecipient, IRecipient<SelectedCustomerChanged>
{
  [ObservableProperty]
  private Customer? selectedCustomer;

  private readonly ICustomerService service;

  public CustomerPageViewModel(ICustomerService service) => this.service = service;

  public void Receive(SelectedCustomerChanged message) => throw new NotImplementedException();
}
