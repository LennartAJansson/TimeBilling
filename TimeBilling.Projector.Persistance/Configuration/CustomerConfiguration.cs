namespace TimeBilling.Projector.Persistance.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TimeBilling.Model;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
  public void Configure(EntityTypeBuilder<Customer> builder)
  {
    _ = builder.ToTable("Customers");

    _ = builder.HasKey(x => x.Id);

    _ = builder.HasData(
        new Customer { Id = new Guid("7A556624-FF3B-43EF-9319-B0359E99245D"), Name = "Lantmäteriet" },
        new Customer { Id = new Guid("7357FDFB-5037-455C-A6D3-499B075185C8"), Name = "Sandvik" },
        new Customer { Id = new Guid("D5855FE7-DED6-4977-AE49-B31600C53D0B"), Name = "Alleima" },
        new Customer { Id = new Guid("B328BD69-F341-4C15-B5AB-65BA6DC9E23D"), Name = "Trafikverket" },
        new Customer { Id = new Guid("37C409CC-C0F8-4496-94AC-103BEDBE362C"), Name = "Coromant" });
  }
}
