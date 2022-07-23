using Rekod.ViewModel;

namespace Rekod.Views;

public partial class AddCardPage : ContentPage
{
	public AddCardPage(AddCardViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}