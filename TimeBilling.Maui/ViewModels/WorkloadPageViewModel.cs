namespace TimeBilling.Maui.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;
using TimeBilling.Maui.Services;

public partial class WorkloadPageViewModel : ObservableRecipient, IRecipient<SelectedWorkloadChanged>
{
  [ObservableProperty]
  private Workload? selectedWorkload;

  private readonly IWorkloadService service;

  public WorkloadPageViewModel(IWorkloadService service)
  {
    Messenger.RegisterAll(this);
    this.service = service;
  }

  public void Receive(SelectedWorkloadChanged message) => SelectedWorkload = message.Value;

  [RelayCommand]
  public void SaveAndExit()
  {
    _ = service.EndWorkload(SelectedWorkload);
    RefreshWorkloadsList message = new(SelectedWorkload);
    _ = WeakReferenceMessenger.Default.Send(message);

    //await ShowToast("Workload saved");

    _ = Shell.Current.Navigation.PopAsync();
    //GoBack();
  }

  [RelayCommand]
  public void GoBack() => Shell.Current.Navigation.PopAsync();
}
