using Microsoft.EntityFrameworkCore.Migrations;

namespace MaestroApp.Migrations
{
    public partial class Addcampoestadotipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "MaestroEstado",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Tipo",
                table: "MaestroEstado",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "MaestroEstado");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "MaestroEstado",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
