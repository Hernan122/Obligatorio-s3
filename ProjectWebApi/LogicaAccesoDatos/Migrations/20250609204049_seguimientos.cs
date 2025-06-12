using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class seguimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    EnvioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguimiento_Envios_EnvioId",
                        column: x => x.EnvioId,
                        principalTable: "Envios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seguimiento_Usuarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_EnvioId",
                table: "Seguimiento",
                column: "EnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_FuncionarioId",
                table: "Seguimiento",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguimiento");
        }
    }
}
