using Microsoft.EntityFrameworkCore.Migrations;

namespace ZooVrt.Persistance.Migrations
{
    public partial class UpdatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Boja",
                table: "TipoviStanista",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TipoviStanista",
                keyColumn: "Id",
                keyValue: 1,
                column: "Boja",
                value: "#b30000");

            migrationBuilder.UpdateData(
                table: "TipoviStanista",
                keyColumn: "Id",
                keyValue: 2,
                column: "Boja",
                value: "#80ff00");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Boja",
                table: "TipoviStanista");
        }
    }
}
