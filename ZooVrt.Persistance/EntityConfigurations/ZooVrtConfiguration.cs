using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using ZooVrt.Domain.Entities;

namespace ZooVrt.Persistance.EntityConfigurations
{
    public class ZooVrtConfiguration: IEntityTypeConfiguration<Domain.Entities.ZooVrt>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.ZooVrt> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new Domain.Entities.ZooVrt()
                {
                    Id = 1,
                    Naziv = "Prvi",
                    M = 3,
                    N = 3,
                    Kapacitet = 7
                },
                new Domain.Entities.ZooVrt()
                {
                    Id = 2,
                    Naziv = "Drugi",
                    M = 3,
                    N = 4,
                    Kapacitet = 9
                });
        }
    }
}