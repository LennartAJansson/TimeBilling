namespace TimeBilling.Maui.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;
using TimeBilling.Maui.Services;

public partial class WorkloadsPageViewModel : ObservableRecipient, IRecipient<RefreshWorkloadsList>
{
  [ObservableProperty]
  private ICollection<Workload> workloads = new List<Workload>();

  [ObservableProperty]
  private Workload? selectedWorkload;
  partial void OnSelectedWorkloadChanged(Workload? value)
  {
    var message = new SelectedWorkloadChanged(value);
    _ = Shell.Current.GoToAsync("Workload");
    _ = WeakReferenceMessenger.Default.Send(message);
  }

  private readonly IWorkloadService service;

  public WorkloadsPageViewModel(IWorkloadService service) => this.service = service;

  public void Receive(RefreshWorkloadsList message) => throw new NotImplementedException();
}
