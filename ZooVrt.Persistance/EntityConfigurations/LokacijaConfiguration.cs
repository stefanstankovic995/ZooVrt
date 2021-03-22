using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooVrt.Domain.Entities;

namespace ZooVrt.Persistance.EntityConfigurations
{
    public class LokacijaConfiguration: IEntityTypeConfiguration<Lokacija>
    {
        public void Configure(EntityTypeBuilder<Lokacija> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Staniste)
                .WithMany()
                .HasForeignKey(x => x.StanisteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ZooVrt)
                .WithMany()
                .HasForeignKey(x => x.ZooVrtId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Lokacija()
                {
                    Id = 1,
                    Vrsta = "Tigar",
                    X = 0,
                    Y = 0,
                    Zbir = 5,
                    StanisteId = 1,
                    ZooVrtId = 2
                },
                new Lokacija()
                {
                    Id = 2,
                    Vrsta = "Macka",
                    X = 0,
                    Y = 1,
                    Zbir = 3,
                    ZooVrtId = 2,
                    StanisteId = 2
                }
                );
        }
    }
}
