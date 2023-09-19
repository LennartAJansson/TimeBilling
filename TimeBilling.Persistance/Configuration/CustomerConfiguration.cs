namespace TimeBilling.Persistance.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TimeBilling.Model;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        _ = builder.ToTable("Customers");

        _ = builder.HasData(
            new Customer { Id = 1, Name = "Lantmäteriet" },
            new Customer { Id = 2, Name = "Sandvik" },
            new Customer { Id = 3, Name = "Alleima" },
            new Customer { Id = 4, Name = "Trafikverket" },
            new Customer { Id = 5, Name = "Coromant" });
    }
}
internal class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        _ = builder.ToTable("People");

        _ = builder.HasData(
            new Person { Id = 1, Name = "Nisse Hult" },
            new Person { Id = 2, Name = "Hasse Hansson" },
            new Person { Id = 3, Name = "Kalle Karlsson" },
            new Person { Id = 4, Name = "Svenne Svensson" },
            new Person { Id = 5, Name = "Lasse Larsson" });
    }
}
internal class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
{
    public void Configure(EntityTypeBuilder<Workload> builder)
    {
        _ = builder.ToTable("Workloads");

        _ = builder.HasData(
            new Workload
            {
                Id = 1,
                CustomerId = 1,
                PersonId = 1,
                Begin = new DateTimeOffset(2023, 8, 1, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 1, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 2,
                CustomerId = 1,
                PersonId = 1,
                Begin = new DateTimeOffset(2023, 8, 2, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 2, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 3,
                CustomerId = 1,
                PersonId = 1,
                Begin = new DateTimeOffset(2023, 8, 3, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 3, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 4,
                CustomerId = 1,
                PersonId = 1,
                Begin = new DateTimeOffset(2023, 8, 4, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 4, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 5,
                CustomerId = 1,
                PersonId = 1,
                Begin = new DateTimeOffset(2023, 8, 5, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 5, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 6,
                CustomerId = 2,
                PersonId = 2,
                Begin = new DateTimeOffset(2023, 8, 1, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 1, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 7,
                CustomerId = 2,
                PersonId = 2,
                Begin = new DateTimeOffset(2023, 8, 2, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 2, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 8,
                CustomerId = 2,
                PersonId = 2,
                Begin = new DateTimeOffset(2023, 8, 3, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 3, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 9,
                CustomerId = 2,
                PersonId = 2,
                Begin = new DateTimeOffset(2023, 8, 4, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 4, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 10,
                CustomerId = 2,
                PersonId = 2,
                Begin = new DateTimeOffset(2023, 8, 5, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 5, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 11,
                CustomerId = 3,
                PersonId = 3,
                Begin = new DateTimeOffset(2023, 8, 1, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 1, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 12,
                CustomerId = 3,
                PersonId = 3,
                Begin = new DateTimeOffset(2023, 8, 2, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 2, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 13,
                CustomerId = 3,
                PersonId = 3,
                Begin = new DateTimeOffset(2023, 8, 3, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 3, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 14,
                CustomerId = 3,
                PersonId = 3,
                Begin = new DateTimeOffset(2023, 8, 4, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 4, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 15,
                CustomerId = 3,
                PersonId = 3,
                Begin = new DateTimeOffset(2023, 8, 5, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 5, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 16,
                CustomerId = 4,
                PersonId = 4,
                Begin = new DateTimeOffset(2023, 8, 1, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 1, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 17,
                CustomerId = 4,
                PersonId = 4,
                Begin = new DateTimeOffset(2023, 8, 2, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 2, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 18,
                CustomerId = 4,
                PersonId = 4,
                Begin = new DateTimeOffset(2023, 8, 3, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 3, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 19,
                CustomerId = 4,
                PersonId = 4,
                Begin = new DateTimeOffset(2023, 8, 4, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 4, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 20,
                CustomerId = 4,
                PersonId = 4,
                Begin = new DateTimeOffset(2023, 8, 5, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 5, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 21,
                CustomerId = 5,
                PersonId = 5,
                Begin = new DateTimeOffset(2023, 8, 1, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 1, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 22,
                CustomerId = 5,
                PersonId = 5,
                Begin = new DateTimeOffset(2023, 8, 2, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 2, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 23,
                CustomerId = 5,
                PersonId = 5,
                Begin = new DateTimeOffset(2023, 8, 3, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 3, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 24,
                CustomerId = 5,
                PersonId = 5,
                Begin = new DateTimeOffset(2023, 8, 4, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 4, 16, 0, 0, TimeSpan.Zero)
            },
            new Workload
            {
                Id = 25,
                CustomerId = 5,
                PersonId = 5,
                Begin = new DateTimeOffset(2023, 8, 5, 8, 0, 0, TimeSpan.Zero),
                End = new DateTimeOffset(2023, 8, 5, 16, 0, 0, TimeSpan.Zero)
            }
        );
    }
}
