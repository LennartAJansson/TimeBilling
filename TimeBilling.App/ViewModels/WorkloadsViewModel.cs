namespace TimeBilling.App.ViewModels;
using System.Collections.Generic;

using CommunityToolkit.Mvvm.ComponentModel;

using TimeBilling.App.Models;
using TimeBilling.App.Services;

public partial class WorkloadsViewModel : ObservableObject
{
    private readonly IRestApiService service;

    [ObservableProperty]
    private ICollection<WorkloadModel> workloads;

    [ObservableProperty]
    private WorkloadModel selectedWorkload;

    public WorkloadsViewModel(IRestApiService service)
    {
        this.service = service;

        Task.Run(async () =>
        {
            workloads = await this.service.GetWorkloads();
            OnPropertyChanged(nameof(Workloads));
        });
    }
}