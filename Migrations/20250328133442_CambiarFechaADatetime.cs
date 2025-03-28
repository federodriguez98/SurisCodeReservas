using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDeReservas.Migrations
{
    /// <inheritdoc />
    public partial class CambiarFechaADatetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Servicio_ServicioId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_ServicioId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "ServicioId",
                table: "Reserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdServicio",
                table: "Reserva",
                column: "IdServicio");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Servicio_IdServicio",
                table: "Reserva",
                column: "IdServicio",
                principalTable: "Servicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Servicio_IdServicio",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdServicio",
                table: "Reserva");

            migrationBuilder.AddColumn<int>(
                name: "ServicioId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ServicioId",
                table: "Reserva",
                column: "ServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Servicio_ServicioId",
                table: "Reserva",
                column: "ServicioId",
                principalTable: "Servicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
