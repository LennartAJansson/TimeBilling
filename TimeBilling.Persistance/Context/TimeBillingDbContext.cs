namespace TimeBilling.Persistance.Context;

using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TimeBilling.Model;

internal class TimeBillingDbContext : DbContext, ITimeBillingDbContext
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
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var item in ChangeTracker
                   .Entries())
                   //.Where(e => e.Entity is Customer && (e.State == EntityState.Added || e.State == EntityState.Modified)))
                   //.Select(e => e.Entity as Customer))
        {

        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
