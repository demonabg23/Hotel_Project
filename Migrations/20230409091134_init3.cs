using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Project_Marti_i_Stanko.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationClients",
                table: "ReservationClients");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ReservationClients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationClients",
                table: "ReservationClients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationClients_ReservationId",
                table: "ReservationClients",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationClients",
                table: "ReservationClients");

            migrationBuilder.DropIndex(
                name: "IX_ReservationClients_ReservationId",
                table: "ReservationClients");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ReservationClients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationClients",
                table: "ReservationClients",
                columns: new[] { "ReservationId", "ClientId" });
        }
    }
}
