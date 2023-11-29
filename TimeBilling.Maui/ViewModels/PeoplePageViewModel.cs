namespace TimeBilling.Maui.ViewModels;
using System.Collections.ObjectModel;

using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;
using TimeBilling.Maui.Services;

public partial class PeoplePageViewModel : ObservableRecipient, IRecipient<RefreshPeopleList>
{
  [ObservableProperty]
  private ObservableCollection<Person> people = [];

  [ObservableProperty]
  private Person? selectedPerson;
  partial void OnSelectedPersonChanged(Person? value)
  {
    var message = new SelectedPersonChanged(value);
    _ = Shell.Current.GoToAsync("Person");
    _ = WeakReferenceMessenger.Default.Send(message);
  }

  public void Receive(RefreshPeopleList message)
  {
    _ = Task.Run(async () =>
        {
          People = (await service.GetPeople()).ToObservableCollection();
        });
    SelectedPerson = null;
  }

  private readonly ITimeBillingService service;

  public PeoplePageViewModel(ITimeBillingService service)
  {
    this.service = service;
    Messenger.RegisterAll(this);
    _ = Task.Run(async () =>
    {
      People = (await service.GetPeople()).ToObservableCollection();
    });
  }
}
