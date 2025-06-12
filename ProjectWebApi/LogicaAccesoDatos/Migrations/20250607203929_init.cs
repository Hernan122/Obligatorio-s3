using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UbPos = table.Column<int>(type: "int", nullable: false),
                    Ubicacion_CoordenadasLatitud = table.Column<int>(type: "int", nullable: false),
                    Ubicacion_CoordenadasLongitud = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auditoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccionRealizada = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Envios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTracking = table.Column<int>(type: "int", nullable: false),
                    PesoPaquete = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AgenciaId = table.Column<int>(type: "int", nullable: true),
                    DireccionPostal = table.Column<int>(type: "int", nullable: true),
                    EntregaEficiente = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Envios_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password_Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnvioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Envios_EnvioId",
                        column: x => x.EnvioId,
                        principalTable: "Envios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencias_Nombre",
                table: "Agencias",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agencias_UsuarioId",
                table: "Agencias",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditoria_UsuarioId",
                table: "Auditoria",
                column: "UsuarioId");

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
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EnvioId",
                table: "Usuarios",
                column: "EnvioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agencias_Usuarios_UsuarioId",
                table: "Agencias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auditoria_Usuarios_UsuarioId",
                table: "Auditoria",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Usuarios_ClienteId",
                table: "Envios",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Usuarios_FuncionarioId",
                table: "Envios",
                column: "FuncionarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencias_Usuarios_UsuarioId",
                table: "Agencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Usuarios_ClienteId",
                table: "Envios");

            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Usuarios_FuncionarioId",
                table: "Envios");

            migrationBuilder.DropTable(
                name: "Auditoria");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Envios");

            migrationBuilder.DropTable(
                name: "Agencias");
        }
    }
}
