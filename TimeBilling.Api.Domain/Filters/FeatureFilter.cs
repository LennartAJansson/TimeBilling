namespace TimeBilling.Api.Domain.Filters;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement;

public abstract class FeatureFilter : IEndpointFilter
{
  protected abstract string FeatureFlag { get; }

  private readonly IFeatureManager _featureManager;

  protected FeatureFilter(IFeatureManager featureManager) => _featureManager = featureManager;

  public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
      EndpointFilterDelegate next)
  {
    bool isEnabled = await _featureManager.IsEnabledAsync(FeatureFlag);
    return !isEnabled ? TypedResults.NotFound() : await next(context);
  }
}
