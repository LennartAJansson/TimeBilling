using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

using TimeBilling.Api.Endpoints;
using TimeBilling.Api.Extensions;
using TimeBilling.Persistance.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApiHandlers()
    .AddDomainRegistrations()
    .AddPersistanceRegistrations(builder.Configuration.GetConnectionString("TimeBillingDb")
        ?? throw new ArgumentException("No connectionstring"));

builder.Services.AddFeatureManagement(builder.Configuration.GetSection("FeatureManagement"))
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
  _ = app.UseSwagger();
  _ = app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.AddWorkloadsEndpoints()
    .AddPeopleEndpoints()
    .AddCustomersEndpoints();

app.Run();
