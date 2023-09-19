using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

using TimeBilling.Api.Endpoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddDomainRegistrations()
    .AddPersistanceRegistrations(builder.Configuration.GetConnectionString("TimeBillingDb")
        ??throw new ArgumentException("No connectionstring"));

builder.Services.AddFeatureManagement(builder.Configuration.GetSection("FeatureManagement"))
    .AddFeatureFilter<PercentageFilter>(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddWorkloadsEndpoints()
    .AddPeopleEndpoints()
    .AddCustomersEndpoints();

app.Run();
