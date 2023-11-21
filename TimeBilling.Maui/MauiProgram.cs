namespace TimeBilling.Maui;

using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;
using TimeBilling.Maui.ViewModels;
using TimeBilling.Maui.Views;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        _ = builder.Services.Setup();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
