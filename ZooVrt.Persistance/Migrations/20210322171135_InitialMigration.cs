using Microsoft.EntityFrameworkCore.Migrations;

namespace ZooVrt.Persistance.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoviStanista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviStanista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZooVrt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N = table.Column<int>(nullable: false),
                    M = table.Column<int>(nullable: false),
                    Kapacitet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZooVrt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    Vrsta = table.Column<string>(nullable: true),
                    Zbir = table.Column<int>(nullable: false),
                    StanisteId = table.Column<int>(nullable: false),
                    ZooVrtId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lokacije_TipoviStanista_StanisteId",
                        column: x => x.StanisteId,
                        principalTable: "TipoviStanista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lokacije_ZooVrt_ZooVrtId",
                        column: x => x.ZooVrtId,
                        principalTable: "ZooVrt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lokacije_StanisteId",
                table: "Lokacije",
                column: "StanisteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacije_ZooVrtId",
                table: "Lokacije",
                column: "ZooVrtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lokacije");

            migrationBuilder.DropTable(
                name: "TipoviStanista");

            migrationBuilder.DropTable(
                name: "ZooVrt");
        }
    }
}
