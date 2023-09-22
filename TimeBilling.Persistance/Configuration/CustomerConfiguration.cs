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
