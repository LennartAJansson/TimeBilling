namespace TimeBilling.App;

using CommunityToolkit.Maui;

using GeneratedCode;

using Microsoft.Extensions.DependencyInjection;

using Refit;

using TimeBilling.App.Services;
using TimeBilling.App.ViewModels;
using TimeBilling.App.Views;

public static class SetupExtensions
{
    public static IServiceCollection Setup(this IServiceCollection services)
    {
        _ = services
            .AddRefitClient(typeof(ITimeBillingApi), svc =>
            {
                //var provider = svc.GetRequiredService<CurrentUser>();
                var settings = new RefitSettings();
                ////TODO! Handle await
                //settings.AuthorizationHeaderValueGetter = async (message, cancellationToken) => provider.JwtToken;
                return settings;
            })
            .ConfigureHttpClient(c =>
            {
                c.Timeout = TimeSpan.FromSeconds(300);
                c.BaseAddress= new Uri("https://localhost:7107/");
                //c.BaseAddress = new Uri(configuration.GetValue<string>("AuthUrl")
                //    ?? throw new ArgumentException("No AuthUrl found in configuration"));
            });

        _ = services.AddSingleton<App>();
        _ = services.AddSingleton<AppShell>();
        _ = services.AddSingleton<MainPage, MainPageViewModel>();
        _ = services.AddTransient<CustomersView, CustomersViewModel>();
        _ = services.AddTransient<PeopleView, PeopleViewModel>();
        _ = services.AddTransient<WorkloadsView, WorkloadsViewModel>();
        services.AddTransient<IRestApiService, RestApiService>();
        services.AddAutoMapper(typeof(SetupExtensions).Assembly);

        return services;
    }
}
