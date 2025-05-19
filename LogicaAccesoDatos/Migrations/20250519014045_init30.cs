using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Agencias_AgenciaId",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Usuarios_ClienteId",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Usuarios_FuncionarioId",
                table: "Envio");

            migrationBuilder.DropTable(
                name: "Seguimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Envio",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "Nombre_Valor",
                table: "Agencias");

            migrationBuilder.DropColumn(
                name: "DireccionPostal",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "EntregaEficiente",
                table: "Envio");

            migrationBuilder.DropColumn(
                name: "SeguimientoId",
                table: "Envio");

            migrationBuilder.RenameTable(
                name: "Envio",
                newName: "Envios");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuarios",
                newName: "Nombre_Valor");

            migrationBuilder.RenameIndex(
                name: "IX_Envio_FuncionarioId",
                table: "Envios",
                newName: "IX_Envios_FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Envio_ClienteId",
                table: "Envios",
                newName: "IX_Envios_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Envio_AgenciaId",
                table: "Envios",
                newName: "IX_Envios_AgenciaId");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Agencias",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Envios",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Envios",
                table: "Envios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Agencias_Nombre",
                table: "Agencias",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Agencias_AgenciaId",
                table: "Envios",
                column: "AgenciaId",
                principalTable: "Agencias",
                principalColumn: "Id");

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
                name: "FK_Envios_Agencias_AgenciaId",
                table: "Envios");

            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Usuarios_ClienteId",
                table: "Envios");

            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Usuarios_FuncionarioId",
                table: "Envios");

            migrationBuilder.DropIndex(
                name: "IX_Agencias_Nombre",
                table: "Agencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Envios",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Agencias");

            migrationBuilder.RenameTable(
                name: "Envios",
                newName: "Envio");

            migrationBuilder.RenameColumn(
                name: "Nombre_Valor",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.RenameIndex(
                name: "IX_Envios_FuncionarioId",
                table: "Envio",
                newName: "IX_Envio_FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Envios_ClienteId",
                table: "Envio",
                newName: "IX_Envio_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Envios_AgenciaId",
                table: "Envio",
                newName: "IX_Envio_AgenciaId");

            migrationBuilder.AddColumn<string>(
                name: "Nombre_Valor",
                table: "Agencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Envio",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<int>(
                name: "DireccionPostal",
                table: "Envio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EntregaEficiente",
                table: "Envio",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeguimientoId",
                table: "Envio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Envio",
                table: "Envio",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Seguimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnvioId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguimientos_Envio_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Envio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seguimientos_Usuarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguimientos_FuncionarioId",
                table: "Seguimientos",
                column: "FuncionarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Agencias_AgenciaId",
                table: "Envio",
                column: "AgenciaId",
                principalTable: "Agencias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Usuarios_ClienteId",
                table: "Envio",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Usuarios_FuncionarioId",
                table: "Envio",
                column: "FuncionarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
