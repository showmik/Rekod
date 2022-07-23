using Rekod.ViewModel;
using Rekod.Views;

namespace Rekod;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddTransient<DeckManagementPage>();
		builder.Services.AddTransient<DeckManagementViewModel>();

        builder.Services.AddTransient<AddCardPage>();
        builder.Services.AddTransient<AddCardViewModel>();

        return builder.Build();
	}
}
