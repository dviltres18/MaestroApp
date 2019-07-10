using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaestroApp.Migrations
{
    public partial class cambioTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaestroViaje_MaestroContenedor_ContenedorId",
                table: "MaestroViaje");

            migrationBuilder.DropIndex(
                name: "IX_MaestroViaje_ContenedorId",
                table: "MaestroViaje");

            migrationBuilder.DropColumn(
                name: "ContenedorId",
                table: "MaestroViaje");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "MaestroEstado");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "MaestroEstado");

            migrationBuilder.DropColumn(
                name: "Responsable",
                table: "MaestroEstado");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "MaestroEstado",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "MaestroEstado");

            migrationBuilder.AddColumn<int>(
                name: "ContenedorId",
                table: "MaestroViaje",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "MaestroEstado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "MaestroEstado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Responsable",
                table: "MaestroEstado",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MaestroViaje_ContenedorId",
                table: "MaestroViaje",
                column: "ContenedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaestroViaje_MaestroContenedor_ContenedorId",
                table: "MaestroViaje",
                column: "ContenedorId",
                principalTable: "MaestroContenedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
