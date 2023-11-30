namespace TimeBilling.Maui.ViewModels;
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
    var message = new SelectedPersonChanged(value);
    _ = Shell.Current.GoToAsync("Person");
    _ = WeakReferenceMessenger.Default.Send(message);
  }

  public void Receive(RefreshPeopleList message)
  {
    People.Where(p => p.PersonId == message.Value.PersonId).First().Name = message.Value.Name;
    SelectedPerson = null;
  }

  private readonly IPeopleService service;

  public PeoplePageViewModel(IPeopleService service)
  {
    this.service = service;
    Messenger.RegisterAll(this);
    _ = Task.Run(async () =>
    {
      People = (await service.GetPeople()).ToList();
    });
  }
}
