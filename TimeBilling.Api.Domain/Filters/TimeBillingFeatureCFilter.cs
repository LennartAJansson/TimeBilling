namespace TimeBilling.Api.Domain.Filters;
using Microsoft.FeatureManagement;

public sealed class TimeBillingFeatureCFilter : FeatureFilter
{
  protected override string FeatureFlag => TimeBillingFlags.FeatureC;

  public TimeBillingFeatureCFilter(IFeatureManager featureManager) : base(featureManager)
  {
  }
}