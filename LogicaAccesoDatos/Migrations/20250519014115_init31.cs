using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencias_Usuarios_UsuarioId",
                table: "Agencias");

            migrationBuilder.DropIndex(
                name: "IX_Envios_AgenciaId",
                table: "Envios");

            migrationBuilder.DropIndex(
                name: "IX_Envios_ClienteId",
                table: "Envios");

            migrationBuilder.DropIndex(
                name: "IX_Envios_FuncionarioId",
                table: "Envios");

            migrationBuilder.CreateTable(
                name: "Seguimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguimiento_Usuarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Envios_AgenciaId",
                table: "Envios",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_ClienteId",
                table: "Envios",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_FuncionarioId",
                table: "Envios",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_FuncionarioId",
                table: "Seguimiento",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agencias_Usuarios_UsuarioId",
                table: "Agencias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencias_Usuarios_UsuarioId",
                table: "Agencias");

            migrationBuilder.DropTable(
                name: "Seguimiento");

            migrationBuilder.DropIndex(
                name: "IX_Envios_AgenciaId",
                table: "Envios");

            migrationBuilder.DropIndex(
                name: "IX_Envios_ClienteId",
                table: "Envios");

            migrationBuilder.DropIndex(
                name: "IX_Envios_FuncionarioId",
                table: "Envios");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_AgenciaId",
                table: "Envios",
                column: "AgenciaId",
                unique: true,
                filter: "[AgenciaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Envios_ClienteId",
                table: "Envios",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Envios_FuncionarioId",
                table: "Envios",
                column: "FuncionarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agencias_Usuarios_UsuarioId",
                table: "Agencias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
