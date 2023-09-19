namespace TimeBilling.Persistance.Context;

using Microsoft.EntityFrameworkCore;

using TimeBilling.Model;

internal interface ITimeBillingDbContext: IDbContext
{
    DbSet<Customer> Customers { get; }
    DbSet<Person> People { get; }
    DbSet<Workload> Workloads { get; }
}
