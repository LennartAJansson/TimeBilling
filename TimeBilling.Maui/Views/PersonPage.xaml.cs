namespace TimeBilling.Maui.Views;

using TimeBilling.Maui.ViewModels;

public partial class PersonPage : ContentPage
{
	public PersonPage(PersonPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}