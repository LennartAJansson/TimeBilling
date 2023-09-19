namespace TimeBilling.App.Views;

using TimeBilling.App.ViewModels;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

