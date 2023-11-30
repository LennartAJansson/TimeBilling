namespace TimeBilling.Maui.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

using TimeBilling.Maui.Models;
using TimeBilling.Maui.Services;

public partial class WorkloadPageViewModel : ObservableRecipient, IRecipient<SelectedWorkloadChanged>
{
  [ObservableProperty]
  private Workload? selectedWorkload;

  private readonly IWorkloadService service;

  public WorkloadPageViewModel(IWorkloadService service) => this.service = service;

  public void Receive(SelectedWorkloadChanged message) => throw new NotImplementedException();
}
