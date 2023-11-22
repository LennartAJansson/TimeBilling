namespace TimeBilling.Maui.ViewModels;
using System.Collections.Generic;
using TimeBilling.Maui.Models;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TimeBilling.Maui.Services;

public partial class PeoplePageViewModel : ObservableObject
{
    [ObservableProperty]
    private ICollection<Person> people = new List<Person>();

    [ObservableProperty]
    private Person? selectedPerson;
    partial void OnSelectedPersonChanged(Person? value)
    {
        var message = new SelectedPersonChanged(value);
        WeakReferenceMessenger.Default.Send<SelectedPersonChanged>(message);
    }

    private readonly ITimeBillingService service;
    public PeoplePageViewModel(ITimeBillingService service)
    {
        this.service = service;
        Task.Run(async () =>
        {
            People = await service.GetPeople();
        });
    }
}
