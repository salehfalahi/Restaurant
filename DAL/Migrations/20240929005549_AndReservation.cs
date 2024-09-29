using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AndReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0239d920-7168-47d7-9973-b3153f47e3e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19512aa3-33bd-46d6-b279-dff9cd39b335");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92078257-662d-41b4-ac01-755f43f0ca86");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonCount = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "065e555e-9e00-403d-858f-11bf95bb5e80", null, "customer", "customer" },
                    { "974235b6-8a70-4657-9964-718bc9fc3bac", null, "manager", "manager" },
                    { "b482cf29-39f1-4b72-aa54-23ef15271c10", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "065e555e-9e00-403d-858f-11bf95bb5e80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "974235b6-8a70-4657-9964-718bc9fc3bac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b482cf29-39f1-4b72-aa54-23ef15271c10");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0239d920-7168-47d7-9973-b3153f47e3e6", null, "customer", "customer" },
                    { "19512aa3-33bd-46d6-b279-dff9cd39b335", null, "manager", "manager" },
                    { "92078257-662d-41b4-ac01-755f43f0ca86", null, "admin", "admin" }
                });
        }
    }
}
