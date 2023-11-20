namespace TimeBilling.Maui.Views;

using TimeBilling.Maui.ViewModels;
using CommunityToolkit.Maui;

public partial class MainPage : ContentPage
{
    int count = 0;
    private readonly MainPageViewModel vm;

    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void CounterBtn_Clicked(object sender, EventArgs e)
    {

    }
}

