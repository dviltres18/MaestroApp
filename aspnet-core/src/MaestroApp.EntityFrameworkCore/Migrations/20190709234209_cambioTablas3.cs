using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MaestroApp.Migrations
{
    public partial class cambioTablas3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaestroViajeContenedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ViajeId = table.Column<int>(nullable: false),
                    ContenedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaestroViajeContenedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaestroViajeContenedor_MaestroContenedor_ContenedorId",
                        column: x => x.ContenedorId,
                        principalTable: "MaestroContenedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaestroViajeContenedor_MaestroViaje_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "MaestroViaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaestroViajeContenedor_ContenedorId",
                table: "MaestroViajeContenedor",
                column: "ContenedorId");

            migrationBuilder.CreateIndex(
                name: "IX_MaestroViajeContenedor_ViajeId",
                table: "MaestroViajeContenedor",
                column: "ViajeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaestroViajeContenedor");
        }
    }
}
