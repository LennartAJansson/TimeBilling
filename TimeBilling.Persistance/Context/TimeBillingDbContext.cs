namespace TimeBilling.Persistance.Context;

using System.Reflection;

using Microsoft.EntityFrameworkCore;

using TimeBilling.Model;

internal sealed class TimeBillingDbContext : DbContext, ITimeBillingDbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Person> People => Set<Person>();
    public DbSet<Workload> Workloads => Set<Workload>();

    public TimeBillingDbContext(DbContextOptions<TimeBillingDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);
}
