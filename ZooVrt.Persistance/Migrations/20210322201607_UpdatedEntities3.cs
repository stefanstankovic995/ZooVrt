using Microsoft.EntityFrameworkCore.Migrations;

namespace ZooVrt.Persistance.Migrations
{
    public partial class UpdatedEntities3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ZooVrt",
                keyColumn: "Id",
                keyValue: 1,
                column: "Naziv",
                value: "Prvi");

            migrationBuilder.UpdateData(
                table: "ZooVrt",
                keyColumn: "Id",
                keyValue: 2,
                column: "Naziv",
                value: "Drugi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ZooVrt",
                keyColumn: "Id",
                keyValue: 1,
                column: "Naziv",
                value: null);

            migrationBuilder.UpdateData(
                table: "ZooVrt",
                keyColumn: "Id",
                keyValue: 2,
                column: "Naziv",
                value: null);
        }
    }
}
