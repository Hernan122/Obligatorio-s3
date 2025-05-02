using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class creacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreUsuario",
                table: "Usuarios",
                newName: "Password_Valor");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "Nombre_Valor");

            migrationBuilder.RenameColumn(
                name: "Contrasenia",
                table: "Usuarios",
                newName: "Email_Valor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password_Valor",
                table: "Usuarios",
                newName: "NombreUsuario");

            migrationBuilder.RenameColumn(
                name: "Nombre_Valor",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Email_Valor",
                table: "Usuarios",
                newName: "Contrasenia");
        }
    }
}
