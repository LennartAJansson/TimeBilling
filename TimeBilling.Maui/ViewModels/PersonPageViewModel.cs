namespace TimeBilling.Maui.ViewModels;

using System.Threading.Tasks;

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;
using TimeBilling.Maui.Services;

public partial class PersonPageViewModel : ObservableRecipient, IRecipient<SelectedPersonChanged>
{
  [ObservableProperty]
  private Person? selectedPerson;

  private readonly IPeopleService service;

  public PersonPageViewModel(IPeopleService service)
  {
    Messenger.RegisterAll(this);
    this.service = service;
  }

  public void Receive(SelectedPersonChanged message) => SelectedPerson = message.Value;

  [RelayCommand]
  public void SaveAndExit()
  {
    _ = service.UpdatePerson(SelectedPerson);
    RefreshPeopleList message = new(SelectedPerson);
    _ = WeakReferenceMessenger.Default.Send(message);

    //await ShowToast("Person saved");

    _ = Shell.Current.Navigation.PopAsync();
    //GoBack();
  }

  private static async Task ShowToast(string text)
  {
    CancellationTokenSource cancellationTokenSource = new();

    ToastDuration duration = ToastDuration.Long;
    double fontSize = 14;

    IToast toast = Toast.Make(text, duration, fontSize);

    await toast.Show(cancellationTokenSource.Token);
  }

  [RelayCommand]
  public void GoBack() => Shell.Current.Navigation.PopAsync();
}