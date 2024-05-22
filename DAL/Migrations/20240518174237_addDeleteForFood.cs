using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addDeleteForFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35e64820-f9f2-4c7f-ada3-246b92fe56e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4178c65a-3194-4c38-abda-b3fd3867f45e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71eda40b-f206-4a74-aca3-43623d0961ab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1833178b-1ed4-4494-b177-7fa23c978277", null, "customer", "customer" },
                    { "9a682299-b8dc-4613-b5c5-7035ae65784f", null, "admin", "admin" },
                    { "ab9ee05e-3648-423d-850e-445d53dac123", null, "manager", "manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1833178b-1ed4-4494-b177-7fa23c978277");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a682299-b8dc-4613-b5c5-7035ae65784f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab9ee05e-3648-423d-850e-445d53dac123");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35e64820-f9f2-4c7f-ada3-246b92fe56e2", null, "customer", "customer" },
                    { "4178c65a-3194-4c38-abda-b3fd3867f45e", null, "admin", "admin" },
                    { "71eda40b-f206-4a74-aca3-43623d0961ab", null, "manager", "manager" }
                });
        }
    }
}
