﻿namespace TimeBilling.Projector.Persistance.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TimeBilling.Model;

internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
  public void Configure(EntityTypeBuilder<Person> builder)
  {
    _ = builder.ToTable("People");

    _ = builder.HasKey(x => x.Id);

    _ = builder.HasData(
        new Person { Id = new Guid("96EE628C-56B2-4F06-9049-668EF56C6D0B"), Name = "Nisse Hult" },
        new Person { Id = new Guid("AD9137C0-83BE-40C3-AB9E-D845C23561EA"), Name = "Hasse Hansson" },
        new Person { Id = new Guid("0B1E1F35-5477-4E3D-A7F3-444DF85EF1E7"), Name = "Kalle Karlsson" },
        new Person { Id = new Guid("EF7B215F-7D19-4921-A5CB-2C19D6C049A9"), Name = "Svenne Svensson" },
        new Person { Id = new Guid("A3BA5544-0B26-4CA4-AC24-141BFC1D051A"), Name = "Lasse Larsson" });
  }
}
