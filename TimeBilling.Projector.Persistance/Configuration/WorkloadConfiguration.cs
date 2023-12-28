namespace TimeBilling.Projector.Persistance.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TimeBilling.Model;

internal sealed class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
{
  public void Configure(EntityTypeBuilder<Workload> builder)
  {
    _ = builder.ToTable("Workloads");

    _ = builder.HasKey(x => x.Id);

    _ = builder.HasData(
        new Workload
        {
          Id = new Guid("BF400770-D10B-41C8-B541-26614CAB9438"),
          CustomerId = new Guid("7A556624-FF3B-43EF-9319-B0359E99245D"),
          PersonId = new Guid("96EE628C-56B2-4F06-9049-668EF56C6D0B"),
          Begin = new DateTimeOffset(2023, 8, 1, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 1, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("642CEE4D-7904-4754-8EE6-A018FDC9CE29"),
          CustomerId = new Guid("7A556624-FF3B-43EF-9319-B0359E99245D"),
          PersonId = new Guid("96EE628C-56B2-4F06-9049-668EF56C6D0B"),
          Begin = new DateTimeOffset(2023, 8, 2, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 2, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("24967834-9B01-4447-871D-C905F8A7CF46"),
          CustomerId = new Guid("7A556624-FF3B-43EF-9319-B0359E99245D"),
          PersonId = new Guid("96EE628C-56B2-4F06-9049-668EF56C6D0B"),
          Begin = new DateTimeOffset(2023, 8, 3, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 3, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("925D3441-78C5-45F0-A7FC-4CC419E591DF"),
          CustomerId = new Guid("7A556624-FF3B-43EF-9319-B0359E99245D"),
          PersonId = new Guid("96EE628C-56B2-4F06-9049-668EF56C6D0B"),
          Begin = new DateTimeOffset(2023, 8, 4, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 4, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("DAC45488-09EA-4A91-8716-FBE254B353EF"),
          CustomerId = new Guid("7A556624-FF3B-43EF-9319-B0359E99245D"),
          PersonId = new Guid("96EE628C-56B2-4F06-9049-668EF56C6D0B"),
          Begin = new DateTimeOffset(2023, 8, 5, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 5, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("DE2D4C7F-9397-462B-B932-BD4BFD8B1062"),
          CustomerId = new Guid("7357FDFB-5037-455C-A6D3-499B075185C8"),
          PersonId = new Guid("AD9137C0-83BE-40C3-AB9E-D845C23561EA"),
          Begin = new DateTimeOffset(2023, 8, 1, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 1, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("EA96CD94-1B3D-4860-B779-30DB9890C069"),
          CustomerId = new Guid("7357FDFB-5037-455C-A6D3-499B075185C8"),
          PersonId = new Guid("AD9137C0-83BE-40C3-AB9E-D845C23561EA"),
          Begin = new DateTimeOffset(2023, 8, 2, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 2, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("13A3D442-010E-49CC-A6C9-B04E907E0011"),
          CustomerId = new Guid("7357FDFB-5037-455C-A6D3-499B075185C8"),
          PersonId = new Guid("AD9137C0-83BE-40C3-AB9E-D845C23561EA"),
          Begin = new DateTimeOffset(2023, 8, 3, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 3, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("723651F9-7C84-47A5-BF03-6E91F9B414A0"),
          CustomerId = new Guid("7357FDFB-5037-455C-A6D3-499B075185C8"),
          PersonId = new Guid("AD9137C0-83BE-40C3-AB9E-D845C23561EA"),
          Begin = new DateTimeOffset(2023, 8, 4, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 4, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("476E01BC-5BD0-4587-A814-7474C86DFB86"),
          CustomerId = new Guid("7357FDFB-5037-455C-A6D3-499B075185C8"),
          PersonId = new Guid("AD9137C0-83BE-40C3-AB9E-D845C23561EA"),
          Begin = new DateTimeOffset(2023, 8, 5, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 5, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("BF874FAB-16B0-4B4B-BFDB-AC3332DAC1DB"),
          CustomerId = new Guid("D5855FE7-DED6-4977-AE49-B31600C53D0B"),
          PersonId = new Guid("0B1E1F35-5477-4E3D-A7F3-444DF85EF1E7"),
          Begin = new DateTimeOffset(2023, 8, 1, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 1, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("04F32CD1-0A97-4AF6-AE38-722179A28EBE"),
          CustomerId = new Guid("D5855FE7-DED6-4977-AE49-B31600C53D0B"),
          PersonId = new Guid("0B1E1F35-5477-4E3D-A7F3-444DF85EF1E7"),
          Begin = new DateTimeOffset(2023, 8, 2, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 2, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("83876C4A-8FFA-47EF-B904-A6B0DD59D114"),
          CustomerId = new Guid("D5855FE7-DED6-4977-AE49-B31600C53D0B"),
          PersonId = new Guid("0B1E1F35-5477-4E3D-A7F3-444DF85EF1E7"),
          Begin = new DateTimeOffset(2023, 8, 3, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 3, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("289A5B5D-84C3-4FF3-BB48-7D94C235D34B"),
          CustomerId = new Guid("D5855FE7-DED6-4977-AE49-B31600C53D0B"),
          PersonId = new Guid("0B1E1F35-5477-4E3D-A7F3-444DF85EF1E7"),
          Begin = new DateTimeOffset(2023, 8, 4, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 4, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("70FDB9FD-D24E-4B80-BDA9-B1D9CB0A990E"),
          CustomerId = new Guid("D5855FE7-DED6-4977-AE49-B31600C53D0B"),
          PersonId = new Guid("0B1E1F35-5477-4E3D-A7F3-444DF85EF1E7"),
          Begin = new DateTimeOffset(2023, 8, 5, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 5, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("6740BAE0-6D79-4A33-B0FE-9CB1531C986C"),
          CustomerId = new Guid("B328BD69-F341-4C15-B5AB-65BA6DC9E23D"),
          PersonId = new Guid("EF7B215F-7D19-4921-A5CB-2C19D6C049A9"),
          Begin = new DateTimeOffset(2023, 8, 1, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 1, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("8E477AD3-AB38-4584-9F92-B2F40C1216DF"),
          CustomerId = new Guid("B328BD69-F341-4C15-B5AB-65BA6DC9E23D"),
          PersonId = new Guid("EF7B215F-7D19-4921-A5CB-2C19D6C049A9"),
          Begin = new DateTimeOffset(2023, 8, 2, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 2, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("2E3D2647-DA7F-4123-82AB-2EAFD9BC21AF"),
          CustomerId = new Guid("B328BD69-F341-4C15-B5AB-65BA6DC9E23D"),
          PersonId = new Guid("EF7B215F-7D19-4921-A5CB-2C19D6C049A9"),
          Begin = new DateTimeOffset(2023, 8, 3, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 3, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("8AF67B8A-19A3-4A49-81A2-05437E422EB0"),
          CustomerId = new Guid("B328BD69-F341-4C15-B5AB-65BA6DC9E23D"),
          PersonId = new Guid("EF7B215F-7D19-4921-A5CB-2C19D6C049A9"),
          Begin = new DateTimeOffset(2023, 8, 4, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 4, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("4A191379-2176-4330-8122-23F4E6003265"),
          CustomerId = new Guid("B328BD69-F341-4C15-B5AB-65BA6DC9E23D"),
          PersonId = new Guid("EF7B215F-7D19-4921-A5CB-2C19D6C049A9"),
          Begin = new DateTimeOffset(2023, 8, 5, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 5, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("7154EEA5-B3C0-4FA8-9F9B-22A449C245C9"),
          CustomerId = new Guid("37C409CC-C0F8-4496-94AC-103BEDBE362C"),
          PersonId = new Guid("A3BA5544-0B26-4CA4-AC24-141BFC1D051A"),
          Begin = new DateTimeOffset(2023, 8, 1, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 1, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("55E1103E-841F-4C32-AAFA-2F470CDC69A6"),
          CustomerId = new Guid("37C409CC-C0F8-4496-94AC-103BEDBE362C"),
          PersonId = new Guid("A3BA5544-0B26-4CA4-AC24-141BFC1D051A"),
          Begin = new DateTimeOffset(2023, 8, 2, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 2, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("098E12F8-7597-4DC4-81A7-E9CAC06D4B08"),
          CustomerId = new Guid("37C409CC-C0F8-4496-94AC-103BEDBE362C"),
          PersonId = new Guid("A3BA5544-0B26-4CA4-AC24-141BFC1D051A"),
          Begin = new DateTimeOffset(2023, 8, 3, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 3, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("1AC357CD-4E10-44E5-83F2-910690EB8682"),
          CustomerId = new Guid("37C409CC-C0F8-4496-94AC-103BEDBE362C"),
          PersonId = new Guid("A3BA5544-0B26-4CA4-AC24-141BFC1D051A"),
          Begin = new DateTimeOffset(2023, 8, 4, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 4, 16, 0, 0, TimeSpan.Zero)
        },
        new Workload
        {
          Id = new Guid("131EC36C-04A3-4181-8C1E-4F50797D4F91"),
          CustomerId = new Guid("37C409CC-C0F8-4496-94AC-103BEDBE362C"),
          PersonId = new Guid("A3BA5544-0B26-4CA4-AC24-141BFC1D051A"),
          Begin = new DateTimeOffset(2023, 8, 5, 8, 0, 0, TimeSpan.Zero),
          End = new DateTimeOffset(2023, 8, 5, 16, 0, 0, TimeSpan.Zero)
        }
    );
  }
}
