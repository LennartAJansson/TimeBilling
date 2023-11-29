namespace TimeBilling.Maui.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;

using TimeBilling.Maui.Models;

public sealed class SelectedPersonChanged(Person person) : ValueChangedMessage<Person>(person) { }
public sealed class RefreshPeopleList(Person? person) : ValueChangedMessage<Person>(person!) { }

