using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaestroApp.Migrations
{
    public partial class cambioenestado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MaestroEstado");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MaestroEstado");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "MaestroEstado");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MaestroEstado");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MaestroEstado");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MaestroEstado");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "MaestroEstado");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "MaestroEstado");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MaestroEstado",
                newName: "EstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "MaestroEstado",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "MaestroEstado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "MaestroEstado",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "MaestroEstado",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MaestroEstado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MaestroEstado",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "MaestroEstado",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "MaestroEstado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Tipo",
                table: "MaestroEstado",
                nullable: false,
                defaultValue: false);
        }
    }
}
