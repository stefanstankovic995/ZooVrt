using Microsoft.EntityFrameworkCore.Migrations;

namespace ZooVrt.Persistance.Migrations
{
    public partial class UpdatedEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "ZooVrt",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "ZooVrt");
        }
    }
}
