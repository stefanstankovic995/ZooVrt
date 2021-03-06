// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooVrt.Persistance.Database;

namespace ZooVrt.Persistance.Migrations
{
    [DbContext(typeof(ZooVrtContext))]
    [Migration("20210323120054_Initial-Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZooVrt.Domain.Entities.Lokacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StanisteId")
                        .HasColumnType("int");

                    b.Property<string>("Vrsta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.Property<int>("Zbir")
                        .HasColumnType("int");

                    b.Property<int>("ZooVrtId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StanisteId");

                    b.HasIndex("ZooVrtId");

                    b.ToTable("Lokacije");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StanisteId = 1,
                            Vrsta = "Tigar",
                            X = 0,
                            Y = 0,
                            Zbir = 5,
                            ZooVrtId = 2
                        },
                        new
                        {
                            Id = 2,
                            StanisteId = 2,
                            Vrsta = "Macka",
                            X = 0,
                            Y = 1,
                            Zbir = 3,
                            ZooVrtId = 2
                        });
                });

            modelBuilder.Entity("ZooVrt.Domain.Entities.TipStanista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoviStanista");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naziv = "Tundra"
                        },
                        new
                        {
                            Id = 2,
                            Naziv = "Savana"
                        });
                });

            modelBuilder.Entity("ZooVrt.Domain.Entities.ZooVrt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int");

                    b.Property<int>("M")
                        .HasColumnType("int");

                    b.Property<int>("N")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ZooVrt");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Kapacitet = 7,
                            M = 3,
                            N = 3,
                            Naziv = "Prvi"
                        },
                        new
                        {
                            Id = 2,
                            Kapacitet = 9,
                            M = 3,
                            N = 4,
                            Naziv = "Drugi"
                        });
                });

            modelBuilder.Entity("ZooVrt.Domain.Entities.Lokacija", b =>
                {
                    b.HasOne("ZooVrt.Domain.Entities.TipStanista", "Staniste")
                        .WithMany()
                        .HasForeignKey("StanisteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ZooVrt.Domain.Entities.ZooVrt", "ZooVrt")
                        .WithMany("Lokacije")
                        .HasForeignKey("ZooVrtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
