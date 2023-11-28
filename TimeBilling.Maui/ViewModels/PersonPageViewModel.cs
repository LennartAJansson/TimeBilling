namespace TimeBilling.Maui.ViewModels;

using System.Threading.Tasks;

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;
using TimeBilling.Maui.Services;

public class Test
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
}

public partial class PersonPageViewModel : ObservableRecipient, IRecipient<SelectedPersonChanged>
{
  [ObservableProperty]
  private Person? selectedPerson;

  [ObservableProperty]
  private float test = 0.4567f;
  private readonly ITimeBillingService service;

  //new() { Id = Guid.NewGuid(), Name = "Funkar inte" };

  public PersonPageViewModel(ITimeBillingService service)
  {
    Messenger.RegisterAll(this);
    this.service = service;
  }

  [RelayCommand]
  public async Task SaveAndExit()
  {
    await service.UpdatePerson(SelectedPerson);
    RefreshPeopleList message = new(SelectedPerson);
    _ = WeakReferenceMessenger.Default.Send(message);

    CancellationTokenSource cancellationTokenSource = new();

    string text = "Person saved";
    ToastDuration duration = ToastDuration.Long;
    double fontSize = 14;

    IToast toast = Toast.Make(text, duration, fontSize);

    await toast.Show(cancellationTokenSource.Token);

    GoBack();
  }

  [RelayCommand]
  public void GoBack() => Shell.Current.Navigation.PopAsync();

  public void Receive(SelectedPersonChanged message) => SelectedPerson = Person.Create(message.Value);
}