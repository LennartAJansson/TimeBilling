using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using Microsoft.OpenApi.Models;

using TimeBilling.Api.Auth;
using TimeBilling.Api.Domain.Endpoints;
using TimeBilling.Api.Domain.Extensions;
using TimeBilling.Api.Persistance.Extensions;
using TimeBilling.Common.Messaging.Extensions;
using TimeBilling.Projector.Domain.Extensions;
using TimeBilling.Projector.Persistance.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiAuth(builder.Configuration)
    .ChangeMailProvider<DummyAuthMail>()
    .AddApiDomainRegistrations()
    .AddApiPersistanceRegistrations()
    //.AddMessagingRegistrations()
    .AddNatsListener(builder.Configuration)
    .AddNatsSender(builder.Configuration)
    .AddProjectorDomainRegistrations()
    .AddProjectorPersistanceRegistrations(builder.Configuration.GetConnectionString("TimeBillingDb")
      ?? throw new ArgumentException("ConnectionString TimeBillingDb not found"))
    .AddFeatureManagement(builder.Configuration.GetSection("FeatureManagement")
        ?? throw new ArgumentException("No feature filters found"))
      .AddFeatureFilter<PercentageFilter>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
  c.EnableAnnotations();
});

builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()));

builder.Services.AddControllers().AddNewtonsoftJson();

WebApplication app = builder.Build();

app.UpdateIdentityDb();

app.ConfigurePersistance();

if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseCors();

app.UseApiAuth();

app.AddWorkloadsEndpoints()
    .AddPeopleEndpoints()
    .AddCustomersEndpoints();

app.Run();
