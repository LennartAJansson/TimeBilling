namespace TimeBilling.App.Views;

using TimeBilling.App.ViewModels;

public partial class WorkloadsView : ContentPage
{
	public WorkloadsView(WorkloadsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}