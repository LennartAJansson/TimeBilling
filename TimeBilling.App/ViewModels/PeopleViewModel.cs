namespace TimeBilling.App.ViewModels;
using System.Collections.Generic;

using CommunityToolkit.Mvvm.ComponentModel;

using TimeBilling.App.Models;
using TimeBilling.App.Services;

public partial class PeopleViewModel : ObservableObject
{
    private readonly IRestApiService service;

    [ObservableProperty]
    private ICollection<PersonModel> people;

    [ObservableProperty]
    private PersonModel selectedPerson;

    public PeopleViewModel(IRestApiService service)
    {
        this.service = service;

        Task.Run(async () => { 
            people = await this.service.GetPeople();
            OnPropertyChanged(nameof(People));
        });
    }
}
