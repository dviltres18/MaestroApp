using Microsoft.EntityFrameworkCore.Migrations;

namespace MaestroApp.Migrations
{
    public partial class addcampoviajeorigen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "MaestroViaje",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origen",
                table: "MaestroViaje");
        }
    }
}
