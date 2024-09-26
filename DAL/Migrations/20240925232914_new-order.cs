using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class neworder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_AspNetUsers_UserId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Orders_OrderId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Foods_OrderId",
                table: "Foods");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a38551e-5101-4f3d-ad75-13969fffb93e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aae8a1d6-6857-4570-9c90-3608edc65bb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f678b680-c199-411d-a88d-b5237fe2244d");

            migrationBuilder.DropColumn(
                name: "TakeOut",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "Table",
                table: "Orders",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "OrderUserId",
                table: "Orders",
                newName: "FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_AppUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Basket",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<byte>(
                name: "Table",
                table: "Basket",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TakeOut",
                table: "Basket",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0239d920-7168-47d7-9973-b3153f47e3e6", null, "customer", "customer" },
                    { "19512aa3-33bd-46d6-b279-dff9cd39b335", null, "manager", "manager" },
                    { "92078257-662d-41b4-ac01-755f43f0ca86", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FoodId",
                table: "Orders",
                column: "FoodId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_AspNetUsers_UserId",
                table: "Basket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserId",
                table: "Orders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Foods_FoodId",
                table: "Orders",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_AspNetUsers_UserId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Foods_FoodId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FoodId",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "Table",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "TakeOut",
                table: "Basket");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "Orders",
                newName: "OrderUserId");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Orders",
                newName: "Table");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "TakeOut",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Basket",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a38551e-5101-4f3d-ad75-13969fffb93e", null, "customer", "customer" },
                    { "aae8a1d6-6857-4570-9c90-3608edc65bb6", null, "manager", "manager" },
                    { "f678b680-c199-411d-a88d-b5237fe2244d", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_OrderId",
                table: "Foods",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_AspNetUsers_UserId",
                table: "Basket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Orders_OrderId",
                table: "Foods",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
