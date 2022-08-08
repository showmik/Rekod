using Rekod.Views;

namespace Rekod;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DeckManagementPage), typeof(DeckManagementPage));
		Routing.RegisterRoute(nameof(AddCardPage), typeof(AddCardPage));
		Routing.RegisterRoute(nameof(StudyPage), typeof(StudyPage));
	}
}
