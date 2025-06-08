using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditoria_Usuarios_UsuarioId",
                table: "Auditoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Envios_EnvioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EnvioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EnvioId",
                table: "Usuarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditoria_Usuarios_UsuarioId",
                table: "Auditoria",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditoria_Usuarios_UsuarioId",
                table: "Auditoria");

            migrationBuilder.AddColumn<int>(
                name: "EnvioId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EnvioId",
                table: "Usuarios",
                column: "EnvioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditoria_Usuarios_UsuarioId",
                table: "Auditoria",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Envios_EnvioId",
                table: "Usuarios",
                column: "EnvioId",
                principalTable: "Envios",
                principalColumn: "Id");
        }
    }
}
