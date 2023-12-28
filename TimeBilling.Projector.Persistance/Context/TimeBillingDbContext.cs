namespace TimeBilling.Projector.Persistance.Context;

using System.Reflection;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using TimeBilling.Model;

internal sealed class TimeBillingDbContext : DbContext, ITimeBillingDbContext
{
  public DbSet<Customer> Customers => Set<Customer>();
  public DbSet<Person> People => Set<Person>();
  public DbSet<Workload> Workloads => Set<Workload>();

  public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
  private ILogger<TimeBillingDbContext>? logger;

  public TimeBillingDbContext(DbContextOptions<TimeBillingDbContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder
          .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    _ = optionsBuilder.UseLoggerFactory(loggerFactory);
    logger = loggerFactory.CreateLogger<TimeBillingDbContext>();
  }

  //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  //{
  //  //foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry item in ChangeTracker
  //  //           .Entries())
  //  //.Where(e => e.Entity is Customer && (e.State == EntityState.Added || e.State == EntityState.Modified)))
  //  //.Select(e => e.Entity as Customer))
  //  {

  //  }
  //  return base.SaveChangesAsync(cancellationToken);
  //}

  public Task EnsureDbExists()
  {
    IEnumerable<string> migrations = Database.GetPendingMigrations();
    if (migrations.Any())
    {
      logger?.LogInformation("Adding {count} migrations", migrations.Count());
      Database.Migrate();
    }
    else
    {
      logger?.LogInformation("Migrations up to date");
    }

    return Task.CompletedTask;
  }

}
