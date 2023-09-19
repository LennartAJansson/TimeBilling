namespace TimeBilling.App.Views;

using TimeBilling.App.ViewModels;

public partial class CustomersView : ContentPage
{
	public CustomersView(CustomersViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}