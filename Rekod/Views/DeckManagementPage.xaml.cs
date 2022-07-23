using Rekod.ViewModel;

namespace Rekod.Views;

public partial class DeckManagementPage : ContentPage
{
	public DeckManagementPage(DeckManagementViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}