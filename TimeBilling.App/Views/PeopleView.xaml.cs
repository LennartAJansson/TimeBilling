namespace TimeBilling.App.Views;

using TimeBilling.App.ViewModels;

public partial class PeopleView : ContentPage
{
	public PeopleView(PeopleViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}