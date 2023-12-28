namespace TimeBilling.Maui.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

  public WorkloadsPageViewModel(IWorkloadService service)
  {
    this.service = service;
    Messenger.RegisterAll(this);
    _ = Task.Run(Refresh);
  }

  [RelayCommand]
  public async Task Refresh() => Workloads = (await service.GetWorkloads()).ToList();

  public void Receive(RefreshWorkloadsList message)
  {
    Workloads.Where(w => w.WorkloadId == message.Value.WorkloadId).First().End = message.Value.End;
    SelectedWorkload = null;
  }
}
