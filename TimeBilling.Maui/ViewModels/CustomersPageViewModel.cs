﻿namespace TimeBilling.Maui.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;
using TimeBilling.Maui.Services;

public partial class CustomersPageViewModel : ObservableRecipient, IRecipient<RefreshCustomersList>
{
  [ObservableProperty]
  private ICollection<Customer> customers = new List<Customer>();

  [ObservableProperty]
  private Customer? selectedCustomer;
  partial void OnSelectedCustomerChanged(Customer? value)
  {
    var message = new SelectedCustomerChanged(value);
    _ = Shell.Current.GoToAsync("Customer");
    _ = WeakReferenceMessenger.Default.Send(message);
  }

  private readonly ICustomerService service;

  public CustomersPageViewModel(ICustomerService service)
  {
    this.service = service;
    Messenger.RegisterAll(this);
    _ = Task.Run(Refresh);
  }

  [RelayCommand]
  public async Task Refresh() => Customers = (await service.GetCustomers()).ToList();

  public void Receive(RefreshCustomersList message)
  {
    Customers.Where(c => c.CustomerId == message.Value.CustomerId).First().Name = message.Value.Name;
    SelectedCustomer = null;
  }
}
