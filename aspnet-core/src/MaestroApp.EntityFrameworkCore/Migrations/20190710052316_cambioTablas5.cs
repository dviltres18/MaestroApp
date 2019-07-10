using Microsoft.EntityFrameworkCore.Migrations;

namespace MaestroApp.Migrations
{
    public partial class cambioTablas5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaestroEstado_MaestroContenedor_ContenedorId",
                table: "MaestroEstado");

            migrationBuilder.DropForeignKey(
                name: "FK_MaestroEstado_MaestroViaje_ViajeId",
                table: "MaestroEstado");

            migrationBuilder.DropIndex(
                name: "IX_MaestroEstado_ContenedorId",
                table: "MaestroEstado");

            migrationBuilder.DropIndex(
                name: "IX_MaestroEstado_ViajeId",
                table: "MaestroEstado");

            migrationBuilder.DropColumn(
                name: "ContenedorId",
                table: "MaestroEstado");

            migrationBuilder.DropColumn(
                name: "ViajeId",
                table: "MaestroEstado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContenedorId",
                table: "MaestroEstado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViajeId",
                table: "MaestroEstado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaestroEstado_ContenedorId",
                table: "MaestroEstado",
                column: "ContenedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaestroEstado_ViajeId",
                table: "MaestroEstado",
                column: "ViajeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaestroEstado_MaestroContenedor_ContenedorId",
                table: "MaestroEstado",
                column: "ContenedorId",
                principalTable: "MaestroContenedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaestroEstado_MaestroViaje_ViajeId",
                table: "MaestroEstado",
                column: "ViajeId",
                principalTable: "MaestroViaje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
