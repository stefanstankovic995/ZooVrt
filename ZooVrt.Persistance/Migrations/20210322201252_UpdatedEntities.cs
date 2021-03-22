using Microsoft.EntityFrameworkCore.Migrations;

namespace ZooVrt.Persistance.Migrations
{
    public partial class UpdatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TipoviStanista",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Tundra" },
                    { 2, "Savana" }
                });

            migrationBuilder.InsertData(
                table: "ZooVrt",
                columns: new[] { "Id", "Kapacitet", "M", "N" },
                values: new object[,]
                {
                    { 1, 7, 3, 3 },
                    { 2, 9, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Lokacije",
                columns: new[] { "Id", "StanisteId", "Vrsta", "X", "Y", "Zbir", "ZooVrtId", "ZooVrtId1" },
                values: new object[] { 1, 1, "Tigar", 0, 0, 5, 2, null });

            migrationBuilder.InsertData(
                table: "Lokacije",
                columns: new[] { "Id", "StanisteId", "Vrsta", "X", "Y", "Zbir", "ZooVrtId", "ZooVrtId1" },
                values: new object[] { 2, 2, "Macka", 0, 1, 3, 2, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lokacije",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lokacije",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ZooVrt",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoviStanista",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoviStanista",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ZooVrt",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
