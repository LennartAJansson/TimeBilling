namespace TimeBilling.Maui.Views;

using TimeBilling.Maui.ViewModels;

public partial class PeoplePage : ContentPage
{
	public PeoplePage(PeoplePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}