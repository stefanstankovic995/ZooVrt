using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ZooVrt.Domain.Entities;

namespace ZooVrt.Persistance.EntityConfigurations
{
    public class TipStanistaConfiguration: IEntityTypeConfiguration<TipStanista>
    {
        public void Configure(EntityTypeBuilder<TipStanista> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new TipStanista()
                {
                    Id = 1,
                    Naziv = "Tundra",
                    Boja = "#b30000"
                },
                new TipStanista()
                {
                    Id = 2,
                    Naziv = "Savana",
                    Boja = "#80ff00"
                });
        }
    }
}
