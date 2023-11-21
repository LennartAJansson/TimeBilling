using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using TimeBilling.Maui.Services;
using TimeBilling.Maui.Models;

namespace TimeBilling.Maui.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ICollection<Person> people = new List<Person>();

    [ObservableProperty]
    private Person? selectedPerson = null;

    [ObservableProperty]
    private string caption = "Click me";

    private int count = default;
    private readonly ITimeBillingService service;

    [RelayCommand]
    public void ButtonPressed()
    {
        count++;

        if (count == 1)
            Caption = $"Clicked {count} time";
        else
            Caption = $"Clicked {count} times";
    }

    public MainPageViewModel(ITimeBillingService service)
    {
        this.service = service;

        Task.Run(async () => 
        {
            People = await service.GetPeople();
        });
    }
}
