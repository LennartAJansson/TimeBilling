namespace TimeBilling.Maui.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;

using TimeBilling.Maui.Models;

//public record SelectedPersonChanged(Person? Person);

public sealed class SelectedPersonChanged : ValueChangedMessage<Person>
{
    public SelectedPersonChanged(Person value) : base(value)
    {
    }
}

public sealed class CurrentUserChanged : ValueChangedMessage<User>
{
    public CurrentUserChanged(User value) : base(value)
    {
    }
}