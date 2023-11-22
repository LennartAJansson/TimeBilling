namespace TimeBilling.Maui.ViewModels;
using TimeBilling.Maui.Models;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

public partial class PersonPageViewModel : ObservableRecipient, IRecipient<SelectedPersonChanged>, IRecipient<CurrentUserChanged>
{
    [ObservableProperty]
    private Person? selectedPerson;

    public PersonPageViewModel()
    {
        Messenger.RegisterAll(this);
    }

    public void Receive(SelectedPersonChanged message) => SelectedPerson = message.Value;
    public void Receive(CurrentUserChanged message) => throw new NotImplementedException();
}