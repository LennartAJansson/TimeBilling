namespace TimeBilling.App.ViewModels;

using System.Collections.Generic;

using CommunityToolkit.Mvvm.ComponentModel;

using TimeBilling.App.Models;
using TimeBilling.App.Services;

public partial class CustomersViewModel: ObservableObject
{
    private readonly IRestApiService service;

    [ObservableProperty]
    private ICollection<CustomerModel> customers;

    [ObservableProperty]
    private CustomerModel selectedCustomer;

    public CustomersViewModel(IRestApiService service)
    {
        this.service = service;

        Task.Run(async () =>
        {
            customers = await this.service.GetCustomers();
            OnPropertyChanged(nameof(Customers));
        });
    }
}
