namespace TimeBilling.Maui.ViewModels;
using System.Collections.Generic;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;
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
    //var page = Ioc.Default.GetRequiredService<PersonPage>();
    //_ = Shell.Current.Navigation.PushModalAsync(page);
    //_ = Shell.Current.Navigation.PushAsync(page);
    _ = Shell.Current.GoToAsync("Person");
    _ = WeakReferenceMessenger.Default.Send(message);
  }

  private readonly ITimeBillingService service;

  public PeoplePageViewModel(ITimeBillingService service)
  {
    this.service = service;
    _ = Task.Run(async () =>
    {
      People = await service.GetPeople();
    });
  }
}
