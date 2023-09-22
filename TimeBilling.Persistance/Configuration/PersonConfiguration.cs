namespace TimeBilling.Persistance.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TimeBilling.Model;

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
