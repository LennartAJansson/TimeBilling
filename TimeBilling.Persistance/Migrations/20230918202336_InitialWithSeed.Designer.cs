﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeBilling.Persistance.Context;

#nullable disable

namespace TimeBilling.Persistance.Migrations
{
    [DbContext(typeof(TimeBillingDbContext))]
    [Migration("20230918202336_InitialWithSeed")]
    partial class InitialWithSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TimeBilling.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lantmäteriet"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sandvik"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Alleima"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Trafikverket"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Coromant"
                        });
                });

            modelBuilder.Entity("TimeBilling.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nisse Hult"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hasse Hansson"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kalle Karlsson"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Svenne Svensson"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Lasse Larsson"
                        });
                });

            modelBuilder.Entity("TimeBilling.Model.Workload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Begin")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("End")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PersonId");

                    b.ToTable("Workloads", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 1,
                            End = new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 1,
                            End = new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 1
                        },
                        new
                        {
                            Id = 3,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 1,
                            End = new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 1
                        },
                        new
                        {
                            Id = 4,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 1,
                            End = new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 1
                        },
                        new
                        {
                            Id = 5,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 1,
                            End = new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 1
                        },
                        new
                        {
                            Id = 6,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 2,
                            End = new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 2
                        },
                        new
                        {
                            Id = 7,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 2,
                            End = new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 2
                        },
                        new
                        {
                            Id = 8,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 2,
                            End = new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 2
                        },
                        new
                        {
                            Id = 9,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 2,
                            End = new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 2
                        },
                        new
                        {
                            Id = 10,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 2,
                            End = new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 2
                        },
                        new
                        {
                            Id = 11,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 3,
                            End = new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 3
                        },
                        new
                        {
                            Id = 12,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 3,
                            End = new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 3
                        },
                        new
                        {
                            Id = 13,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 3,
                            End = new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 3
                        },
                        new
                        {
                            Id = 14,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 3,
                            End = new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 3
                        },
                        new
                        {
                            Id = 15,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 3,
                            End = new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 3
                        },
                        new
                        {
                            Id = 16,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 4,
                            End = new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 4
                        },
                        new
                        {
                            Id = 17,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 4,
                            End = new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 4
                        },
                        new
                        {
                            Id = 18,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 4,
                            End = new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 4
                        },
                        new
                        {
                            Id = 19,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 4,
                            End = new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 4
                        },
                        new
                        {
                            Id = 20,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 4,
                            End = new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 4
                        },
                        new
                        {
                            Id = 21,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 5,
                            End = new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 5
                        },
                        new
                        {
                            Id = 22,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 5,
                            End = new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 5
                        },
                        new
                        {
                            Id = 23,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 5,
                            End = new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 5
                        },
                        new
                        {
                            Id = 24,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 5,
                            End = new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 5
                        },
                        new
                        {
                            Id = 25,
                            Begin = new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            CustomerId = 5,
                            End = new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PersonId = 5
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
