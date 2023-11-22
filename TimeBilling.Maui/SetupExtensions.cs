using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using TimeBilling.Maui.Services;
using TimeBilling.Maui.ViewModels;
using TimeBilling.Maui.Views;
using GeneratedCode;
using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;

namespace TimeBilling.Maui
{
    public static class SetupExtensions
    {
        public static IServiceCollection Setup(this IServiceCollection services)
        {
            _ = services
                .AddRefitClient(typeof(ITimeBillingApi), svc =>
                {
                    var settings = new RefitSettings();
                    return settings;
                })
                .ConfigureHttpClient(c =>
                {
                    c.Timeout = System.TimeSpan.FromSeconds(300);
                    c.BaseAddress = new Uri("https://localhost:7107/");
                    //c.BaseAddress = new Uri(configuration.GetValue<string>("AuthUrl")
                    //    ?? throw new ArgumentException("No AuthUrl found in configuration"));
                });

            _ = services.AddSingleton<App>();
            _ = services.AddSingleton<AppShell>();
            _ = services.AddSingleton<MainPage, MainPageViewModel>();
            _ = services.AddSingleton<PeoplePage, PeoplePageViewModel>();
            _ = services.AddSingleton<PersonPage, PersonPageViewModel>();
            services.AddTransient<ITimeBillingService, TimeBillingService>();
            services.AddAutoMapper(typeof(SetupExtensions).Assembly);

            return services;
        }
    }
}
