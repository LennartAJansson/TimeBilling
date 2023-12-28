using TimeBilling.Projector.Domain.Extensions;
using TimeBilling.Projector.Persistance.Extensions;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddProjectorDomainRegistrations();
builder.Services.AddProjectorPersistanceRegistrations(builder.Configuration.GetConnectionString("TimeBillingDb")
  ?? throw new ArgumentException("Connectionstring TimeBillingDb not found"));

IHost app = builder.Build();

app.ConfigurePersistance();

app.Run();
