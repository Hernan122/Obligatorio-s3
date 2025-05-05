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
                name: "FK_Envio_Agencias_AgenciaId",
                table: "Envio");

            migrationBuilder.DropIndex(
                name: "IX_Envio_AgenciaId",
                table: "Envio");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_AgenciaId",
                table: "Envio",
                column: "AgenciaId",
                unique: true,
                filter: "[AgenciaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Agencias_AgenciaId",
                table: "Envio",
                column: "AgenciaId",
                principalTable: "Agencias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Agencias_AgenciaId",
                table: "Envio");

            migrationBuilder.DropIndex(
                name: "IX_Envio_AgenciaId",
                table: "Envio");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_AgenciaId",
                table: "Envio",
                column: "AgenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Agencias_AgenciaId",
                table: "Envio",
                column: "AgenciaId",
                principalTable: "Agencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
