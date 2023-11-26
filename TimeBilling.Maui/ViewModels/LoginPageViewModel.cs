namespace TimeBilling.Maui.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;

public partial class LoginPageViewModel : ObservableObject
{
  [ObservableProperty]
  private string username = string.Empty;
  partial void OnUsernameChanged(string? oldValue, string newValue)
  {
  }

  [ObservableProperty]
  private string password = string.Empty;
  partial void OnPasswordChanged(string? oldValue, string newValue)
  {
  }
}
