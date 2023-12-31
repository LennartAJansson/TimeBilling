﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using TimeBilling.Projector.Persistance.Context;

#nullable disable

namespace TimeBilling.Projector.Persistance.Migrations
{
  [DbContext(typeof(TimeBillingDbContext))]
  partial class TimeBillingDbContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "8.0.0")
          .HasAnnotation("Relational:MaxIdentifierLength", 64);

      modelBuilder.Entity("TimeBilling.Model.Customer", b =>
          {
            b.Property<Guid>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)");

            b.Property<string>("Name")
                      .HasColumnType("longtext");

            b.HasKey("Id");

            b.ToTable("Customers", (string)null);

            b.HasData(
                      new
                      {
                        Id = new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"),
                        Name = "Lantmäteriet"
                      },
                      new
                      {
                        Id = new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"),
                        Name = "Sandvik"
                      },
                      new
                      {
                        Id = new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"),
                        Name = "Alleima"
                      },
                      new
                      {
                        Id = new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"),
                        Name = "Trafikverket"
                      },
                      new
                      {
                        Id = new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"),
                        Name = "Coromant"
                      });
          });

      modelBuilder.Entity("TimeBilling.Model.Person", b =>
          {
            b.Property<Guid>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)");

            b.Property<string>("Name")
                      .HasColumnType("longtext");

            b.HasKey("Id");

            b.ToTable("People", (string)null);

            b.HasData(
                      new
                      {
                        Id = new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b"),
                        Name = "Nisse Hult"
                      },
                      new
                      {
                        Id = new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea"),
                        Name = "Hasse Hansson"
                      },
                      new
                      {
                        Id = new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7"),
                        Name = "Kalle Karlsson"
                      },
                      new
                      {
                        Id = new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9"),
                        Name = "Svenne Svensson"
                      },
                      new
                      {
                        Id = new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a"),
                        Name = "Lasse Larsson"
                      });
          });

      modelBuilder.Entity("TimeBilling.Model.Workload", b =>
          {
            b.Property<Guid>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("char(36)");

            b.Property<DateTimeOffset>("Begin")
                      .HasColumnType("datetime(6)");

            b.Property<Guid>("CustomerId")
                      .HasColumnType("char(36)");

            b.Property<DateTimeOffset?>("End")
                      .HasColumnType("datetime(6)");

            b.Property<Guid>("PersonId")
                      .HasColumnType("char(36)");

            b.HasKey("Id");

            b.HasIndex("CustomerId");

            b.HasIndex("PersonId");

            b.ToTable("Workloads", (string)null);

            b.HasData(
                      new
                      {
                        Id = new Guid("bf400770-d10b-41c8-b541-26614cab9438"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b")
                      },
                      new
                      {
                        Id = new Guid("642cee4d-7904-4754-8ee6-a018fdc9ce29"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b")
                      },
                      new
                      {
                        Id = new Guid("24967834-9b01-4447-871d-c905f8a7cf46"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b")
                      },
                      new
                      {
                        Id = new Guid("925d3441-78c5-45f0-a7fc-4cc419e591df"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b")
                      },
                      new
                      {
                        Id = new Guid("dac45488-09ea-4a91-8716-fbe254b353ef"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b")
                      },
                      new
                      {
                        Id = new Guid("de2d4c7f-9397-462b-b932-bd4bfd8b1062"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea")
                      },
                      new
                      {
                        Id = new Guid("ea96cd94-1b3d-4860-b779-30db9890c069"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea")
                      },
                      new
                      {
                        Id = new Guid("13a3d442-010e-49cc-a6c9-b04e907e0011"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea")
                      },
                      new
                      {
                        Id = new Guid("723651f9-7c84-47a5-bf03-6e91f9b414a0"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea")
                      },
                      new
                      {
                        Id = new Guid("476e01bc-5bd0-4587-a814-7474c86dfb86"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea")
                      },
                      new
                      {
                        Id = new Guid("bf874fab-16b0-4b4b-bfdb-ac3332dac1db"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7")
                      },
                      new
                      {
                        Id = new Guid("04f32cd1-0a97-4af6-ae38-722179a28ebe"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7")
                      },
                      new
                      {
                        Id = new Guid("83876c4a-8ffa-47ef-b904-a6b0dd59d114"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7")
                      },
                      new
                      {
                        Id = new Guid("289a5b5d-84c3-4ff3-bb48-7d94c235d34b"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7")
                      },
                      new
                      {
                        Id = new Guid("70fdb9fd-d24e-4b80-bda9-b1d9cb0a990e"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7")
                      },
                      new
                      {
                        Id = new Guid("6740bae0-6d79-4a33-b0fe-9cb1531c986c"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9")
                      },
                      new
                      {
                        Id = new Guid("8e477ad3-ab38-4584-9f92-b2f40c1216df"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9")
                      },
                      new
                      {
                        Id = new Guid("2e3d2647-da7f-4123-82ab-2eafd9bc21af"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9")
                      },
                      new
                      {
                        Id = new Guid("8af67b8a-19a3-4a49-81a2-05437e422eb0"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9")
                      },
                      new
                      {
                        Id = new Guid("4a191379-2176-4330-8122-23f4e6003265"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9")
                      },
                      new
                      {
                        Id = new Guid("7154eea5-b3c0-4fa8-9f9b-22a449c245c9"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a")
                      },
                      new
                      {
                        Id = new Guid("55e1103e-841f-4c32-aafa-2f470cdc69a6"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a")
                      },
                      new
                      {
                        Id = new Guid("098e12f8-7597-4dc4-81a7-e9cac06d4b08"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a")
                      },
                      new
                      {
                        Id = new Guid("1ac357cd-4e10-44e5-83f2-910690eb8682"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a")
                      },
                      new
                      {
                        Id = new Guid("131ec36c-04a3-4181-8c1e-4f50797d4f91"),
                        Begin = new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        CustomerId = new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"),
                        End = new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                        PersonId = new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a")
                      });
          });

      modelBuilder.Entity("TimeBilling.Model.Workload", b =>
          {
            b.HasOne("TimeBilling.Model.Customer", "Customer")
                      .WithMany("Workloads")
                      .HasForeignKey("CustomerId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.HasOne("TimeBilling.Model.Person", "Person")
                      .WithMany("Workloads")
                      .HasForeignKey("PersonId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Customer");

            b.Navigation("Person");
          });

      modelBuilder.Entity("TimeBilling.Model.Customer", b =>
          {
            b.Navigation("Workloads");
          });

      modelBuilder.Entity("TimeBilling.Model.Person", b =>
          {
            b.Navigation("Workloads");
          });
#pragma warning restore 612, 618
    }
  }
}
