namespace TimeBilling.Api.Domain.Filters;
using Microsoft.FeatureManagement;

public sealed class TimeBillingFeatureBFilter : FeatureFilter
{
  protected override string FeatureFlag => TimeBillingFlags.FeatureB;

  public TimeBillingFeatureBFilter(IFeatureManager featureManager) : base(featureManager)
  {
  }
}
