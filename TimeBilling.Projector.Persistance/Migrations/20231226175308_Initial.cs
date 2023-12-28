#nullable disable


namespace TimeBilling.Projector.Persistance.Migrations;

using System;

using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    _ = migrationBuilder.AlterDatabase()
        .Annotation("MySql:CharSet", "utf8mb4");

    _ = migrationBuilder.CreateTable(
        name: "Customers",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
          Name = table.Column<string>(type: "longtext", nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
        },
        constraints: table =>
        {
          _ = table.PrimaryKey("PK_Customers", x => x.Id);
        })
        .Annotation("MySql:CharSet", "utf8mb4");

    _ = migrationBuilder.CreateTable(
        name: "People",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
          Name = table.Column<string>(type: "longtext", nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
        },
        constraints: table =>
        {
          _ = table.PrimaryKey("PK_People", x => x.Id);
        })
        .Annotation("MySql:CharSet", "utf8mb4");

    _ = migrationBuilder.CreateTable(
        name: "Workloads",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
          CustomerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
          PersonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
          Begin = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
          End = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
        },
        constraints: table =>
        {
          _ = table.PrimaryKey("PK_Workloads", x => x.Id);
          _ = table.ForeignKey(
                    name: "FK_Workloads_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
          _ = table.ForeignKey(
                    name: "FK_Workloads_People_PersonId",
                    column: x => x.PersonId,
                    principalTable: "People",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
        })
        .Annotation("MySql:CharSet", "utf8mb4");

    _ = migrationBuilder.InsertData(
        table: "Customers",
        columns: new[] { "Id", "Name" },
        values: new object[,]
        {
                  { new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"), "Coromant" },
                  { new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"), "Sandvik" },
                  { new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"), "Lantmäteriet" },
                  { new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"), "Trafikverket" },
                  { new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"), "Alleima" }
        });

    _ = migrationBuilder.InsertData(
        table: "People",
        columns: new[] { "Id", "Name" },
        values: new object[,]
        {
                  { new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7"), "Kalle Karlsson" },
                  { new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b"), "Nisse Hult" },
                  { new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a"), "Lasse Larsson" },
                  { new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea"), "Hasse Hansson" },
                  { new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9"), "Svenne Svensson" }
        });

    _ = migrationBuilder.InsertData(
        table: "Workloads",
        columns: new[] { "Id", "Begin", "CustomerId", "End", "PersonId" },
        values: new object[,]
        {
                  { new Guid("04f32cd1-0a97-4af6-ae38-722179a28ebe"), new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"), new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7") },
                  { new Guid("098e12f8-7597-4dc4-81a7-e9cac06d4b08"), new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"), new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a") },
                  { new Guid("131ec36c-04a3-4181-8c1e-4f50797d4f91"), new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"), new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a") },
                  { new Guid("13a3d442-010e-49cc-a6c9-b04e907e0011"), new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"), new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea") },
                  { new Guid("1ac357cd-4e10-44e5-83f2-910690eb8682"), new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"), new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a") },
                  { new Guid("24967834-9b01-4447-871d-c905f8a7cf46"), new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"), new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b") },
                  { new Guid("289a5b5d-84c3-4ff3-bb48-7d94c235d34b"), new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"), new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7") },
                  { new Guid("2e3d2647-da7f-4123-82ab-2eafd9bc21af"), new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"), new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9") },
                  { new Guid("476e01bc-5bd0-4587-a814-7474c86dfb86"), new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"), new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea") },
                  { new Guid("4a191379-2176-4330-8122-23f4e6003265"), new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"), new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9") },
                  { new Guid("55e1103e-841f-4c32-aafa-2f470cdc69a6"), new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"), new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a") },
                  { new Guid("642cee4d-7904-4754-8ee6-a018fdc9ce29"), new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"), new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b") },
                  { new Guid("6740bae0-6d79-4a33-b0fe-9cb1531c986c"), new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"), new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9") },
                  { new Guid("70fdb9fd-d24e-4b80-bda9-b1d9cb0a990e"), new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"), new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7") },
                  { new Guid("7154eea5-b3c0-4fa8-9f9b-22a449c245c9"), new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("37c409cc-c0f8-4496-94ac-103bedbe362c"), new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("a3ba5544-0b26-4ca4-ac24-141bfc1d051a") },
                  { new Guid("723651f9-7c84-47a5-bf03-6e91f9b414a0"), new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"), new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea") },
                  { new Guid("83876c4a-8ffa-47ef-b904-a6b0dd59d114"), new DateTimeOffset(new DateTime(2023, 8, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"), new DateTimeOffset(new DateTime(2023, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7") },
                  { new Guid("8af67b8a-19a3-4a49-81a2-05437e422eb0"), new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"), new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9") },
                  { new Guid("8e477ad3-ab38-4584-9f92-b2f40c1216df"), new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b328bd69-f341-4c15-b5ab-65ba6dc9e23d"), new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ef7b215f-7d19-4921-a5cb-2c19d6c049a9") },
                  { new Guid("925d3441-78c5-45f0-a7fc-4cc419e591df"), new DateTimeOffset(new DateTime(2023, 8, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"), new DateTimeOffset(new DateTime(2023, 8, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b") },
                  { new Guid("bf400770-d10b-41c8-b541-26614cab9438"), new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"), new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b") },
                  { new Guid("bf874fab-16b0-4b4b-bfdb-ac3332dac1db"), new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("d5855fe7-ded6-4977-ae49-b31600c53d0b"), new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("0b1e1f35-5477-4e3d-a7f3-444df85ef1e7") },
                  { new Guid("dac45488-09ea-4a91-8716-fbe254b353ef"), new DateTimeOffset(new DateTime(2023, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7a556624-ff3b-43ef-9319-b0359e99245d"), new DateTimeOffset(new DateTime(2023, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("96ee628c-56b2-4f06-9049-668ef56c6d0b") },
                  { new Guid("de2d4c7f-9397-462b-b932-bd4bfd8b1062"), new DateTimeOffset(new DateTime(2023, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"), new DateTimeOffset(new DateTime(2023, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea") },
                  { new Guid("ea96cd94-1b3d-4860-b779-30db9890c069"), new DateTimeOffset(new DateTime(2023, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("7357fdfb-5037-455c-a6d3-499b075185c8"), new DateTimeOffset(new DateTime(2023, 8, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ad9137c0-83be-40c3-ab9e-d845c23561ea") }
        });

    _ = migrationBuilder.CreateIndex(
        name: "IX_Workloads_CustomerId",
        table: "Workloads",
        column: "CustomerId");

    _ = migrationBuilder.CreateIndex(
        name: "IX_Workloads_PersonId",
        table: "Workloads",
        column: "PersonId");
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    _ = migrationBuilder.DropTable(
        name: "Workloads");

    _ = migrationBuilder.DropTable(
        name: "Customers");

    _ = migrationBuilder.DropTable(
        name: "People");
  }
}
