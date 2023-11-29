namespace TimeBilling.Maui;

using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    MauiAppBuilder builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .UseMauiCommunityToolkit()
        .UseMauiCommunityToolkitMarkup()
        .ConfigureFonts(fonts =>
        {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
          fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });

    _ = builder.Services.Setup();

#if DEBUG
    builder.Logging.AddDebug();
#endif

    MauiApp mauiApp = builder.Build();
    Ioc.Default.ConfigureServices(mauiApp.Services);

    return mauiApp;
  }
}
