namespace TimeBilling.Maui;

using CommunityToolkit.Maui;

using GeneratedCode;

using Refit;

using TimeBilling.Maui.Services;
using TimeBilling.Maui.ViewModels;
using TimeBilling.Maui.Views;

public static class SetupExtensions
{
  public static IServiceCollection Setup(this IServiceCollection services)
  {
    _ = services
        .AddRefitClient(typeof(ITimeBillingApi), svc =>
        {
          RefitSettings settings = new();
          return settings;
        })
        .ConfigureHttpClient(c =>
        {
          c.Timeout = TimeSpan.FromSeconds(300);
          c.BaseAddress = new Uri("http://timebilling.local:8080/");
          //c.BaseAddress = new Uri(configuration.GetValue<string>("AuthUrl")
          //    ?? throw new ArgumentException("No AuthUrl found in configuration"));
        });

    _ = services.AddSingleton<App>();
    _ = services.AddSingleton<AppShell>();
    _ = services.AddSingleton<MainPage, MainPageViewModel>();
    _ = services.AddSingleton<LoginPage, LoginPageViewModel>();

    _ = services.AddSingleton<PeoplePage, PeoplePageViewModel>();
    _ = services.AddSingleton<PersonPage, PersonPageViewModel>();
    _ = services.AddTransient<IPeopleService, PeopleService>();

    _ = services.AddSingleton<CustomersPage, CustomersPageViewModel>();
    _ = services.AddSingleton<CustomerPage, CustomerPageViewModel>();
    _ = services.AddTransient<ICustomerService, CustomerService>();

    _ = services.AddSingleton<WorkloadsPage, WorkloadsPageViewModel>();
    _ = services.AddSingleton<WorkloadPage, WorkloadPageViewModel>();
    _ = services.AddTransient<IWorkloadService, WorkloadService>();

    _ = services.AddAutoMapper(typeof(SetupExtensions).Assembly);

    return services;
  }
}
