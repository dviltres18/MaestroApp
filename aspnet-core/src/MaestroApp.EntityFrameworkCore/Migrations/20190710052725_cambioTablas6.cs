using Microsoft.EntityFrameworkCore.Migrations;

namespace MaestroApp.Migrations
{
    public partial class cambioTablas6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "MaestroViaje",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "MaestroContenedor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaestroViaje_EstadoId",
                table: "MaestroViaje",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_MaestroContenedor_EstadoId",
                table: "MaestroContenedor",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaestroContenedor_MaestroEstado_EstadoId",
                table: "MaestroContenedor",
                column: "EstadoId",
                principalTable: "MaestroEstado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaestroViaje_MaestroEstado_EstadoId",
                table: "MaestroViaje",
                column: "EstadoId",
                principalTable: "MaestroEstado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaestroContenedor_MaestroEstado_EstadoId",
                table: "MaestroContenedor");

            migrationBuilder.DropForeignKey(
                name: "FK_MaestroViaje_MaestroEstado_EstadoId",
                table: "MaestroViaje");

            migrationBuilder.DropIndex(
                name: "IX_MaestroViaje_EstadoId",
                table: "MaestroViaje");

            migrationBuilder.DropIndex(
                name: "IX_MaestroContenedor_EstadoId",
                table: "MaestroContenedor");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "MaestroViaje");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "MaestroContenedor");
        }
    }
}
