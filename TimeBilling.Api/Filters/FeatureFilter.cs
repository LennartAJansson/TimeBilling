namespace TimeBilling.Api.Filters;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement;

public abstract class FeatureFilter : IEndpointFilter
{
    protected abstract string FeatureFlag { get; }

    private readonly IFeatureManager _featureManager;

    protected FeatureFilter(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var isEnabled = await _featureManager.IsEnabledAsync(FeatureFlag);
        if (!isEnabled)
        {
            return TypedResults.NotFound();
        }

        return await next(context);
    }
}

public class TimeBillingFeatureAFilter : FeatureFilter
{
    protected override string FeatureFlag => TimeBillingFlags.FeatureA;

    public TimeBillingFeatureAFilter(IFeatureManager featureManager) : base(featureManager)
    {
    }
}

public class TimeBillingFeatureBFilter : FeatureFilter
{
    protected override string FeatureFlag => TimeBillingFlags.FeatureB;

    public TimeBillingFeatureBFilter(IFeatureManager featureManager) : base(featureManager)
    {
    }
}

public class TimeBillingFeatureCFilter : FeatureFilter
{
    protected override string FeatureFlag => TimeBillingFlags.FeatureC;

    public TimeBillingFeatureCFilter(IFeatureManager featureManager) : base(featureManager)
    {
    }
}