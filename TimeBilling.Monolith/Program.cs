using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

using TimeBilling.Api.Domain.Endpoints;
using TimeBilling.Api.Domain.Extensions;
using TimeBilling.Api.Persistance.Extensions;
using TimeBilling.Common.Messaging.Extensions;
using TimeBilling.Projector.Domain.Extensions;
using TimeBilling.Projector.Persistance.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiDomainRegistrations()
    .AddApiPersistanceRegistrations()
    .AddMessagingRegistrations()
    .AddProjectorDomainRegistrations()
    .AddProjectorPersistanceRegistrations(builder.Configuration.GetConnectionString("TimeBillingDb")
      ?? throw new ArgumentException("ConnectionString TimeBillingDb not found"))
    .AddFeatureManagement(builder.Configuration.GetSection("FeatureManagement")
        ?? throw new ArgumentException("No feature filters found"))
      .AddFeatureFilter<PercentageFilter>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()));

WebApplication app = builder.Build();

app.ConfigurePersistance();

if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

//app.UseHttpsRedirection();

app.AddWorkloadsEndpoints()
    .AddPeopleEndpoints()
    .AddCustomersEndpoints();

app.Run();
