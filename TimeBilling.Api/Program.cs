using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

using TimeBilling.Api.Domain.Endpoints;
using TimeBilling.Api.Domain.Extensions;
using TimeBilling.Api.Persistance.Extensions;
using TimeBilling.Common.Messaging.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiDomainRegistrations()
    .AddApiPersistanceRegistrations()
    .AddMessagingRegistrations()
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

if (app.Environment.IsDevelopment())
{
}
_ = app.UseSwagger();
_ = app.UseSwaggerUI();

app.UseCors();

//app.UseHttpsRedirection();

app.AddWorkloadsEndpoints()
    .AddPeopleEndpoints()
    .AddCustomersEndpoints();

app.Run();
