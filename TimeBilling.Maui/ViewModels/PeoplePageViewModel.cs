namespace TimeBilling.Maui.ViewModels;
using System.Collections.Generic;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;
using TimeBilling.Maui.Services;

public partial class PeoplePageViewModel : ObservableRecipient, IRecipient<RefreshPeopleList>
{
  [ObservableProperty]
  private ICollection<Person> people = new List<Person>();

  [ObservableProperty]
  private Person? selectedPerson;
  partial void OnSelectedPersonChanged(Person? value)
  {
    if (value is null)
      return;

    var message = new SelectedPersonChanged(value);
    _ = Shell.Current.GoToAsync("Person");
    _ = WeakReferenceMessenger.Default.Send(message);
  }

  public void Receive(RefreshPeopleList message)
  {
    _ = Task.Run(async () =>
        {
          People = await service.GetPeople();
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
      People = await service.GetPeople();
    });
  }
}
