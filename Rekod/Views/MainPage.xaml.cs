using Rekod.Model;
using Rekod.ViewModel;

namespace Rekod;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
        InitializeComponent();
		BindingContext = vm;
	}
}

