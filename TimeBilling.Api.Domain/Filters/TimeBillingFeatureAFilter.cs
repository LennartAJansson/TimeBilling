namespace TimeBilling.Api.Domain.Filters;
using Microsoft.FeatureManagement;

public sealed class TimeBillingFeatureAFilter : FeatureFilter
{
  protected override string FeatureFlag => TimeBillingFlags.FeatureA;

  public TimeBillingFeatureAFilter(IFeatureManager featureManager) : base(featureManager)
  {
  }
}
