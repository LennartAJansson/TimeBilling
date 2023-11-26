namespace TimeBilling.Maui.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;

public partial class PersonPageViewModel : ObservableRecipient, IRecipient<SelectedPersonChanged>
{
  [ObservableProperty]
  private Person? selectedPerson;

  public PersonPageViewModel() => Messenger.RegisterAll(this);

  [RelayCommand]
  public static void GoBack() => Shell.Current.Navigation.PopAsync();

  public void Receive(SelectedPersonChanged message) => SelectedPerson = message.Value;
}