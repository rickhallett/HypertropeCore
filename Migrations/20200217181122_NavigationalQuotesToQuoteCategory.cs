using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class NavigationalQuotesToQuoteCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38ed5e70-d274-4249-b932-5773f0a7d0d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ed0c694-edd4-4f0f-b126-c4a0ba733836");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35815486-38d6-4af0-927c-5bcf1f3439c5", "03c96baa-57b6-4f7d-bdf3-a35bbdf3dba5", "Superadmin", "SUPERADMIN" },
                    { "083f87b8-3742-400b-bcfd-78e35555c1e1", "e24ac6e7-9e51-4404-b5b6-a2f8bc73c2c7", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 17, 18, 11, 19, 980, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 17, 18, 11, 19, 981, DateTimeKind.Local).AddTicks(160));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "083f87b8-3742-400b-bcfd-78e35555c1e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35815486-38d6-4af0-927c-5bcf1f3439c5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ed0c694-edd4-4f0f-b126-c4a0ba733836", "cf425481-9abd-4b13-9125-b5a5d5075c72", "Superadmin", "SUPERADMIN" },
                    { "38ed5e70-d274-4249-b932-5773f0a7d0d6", "9072d0d3-29a3-40dd-8bc6-46e2ee38bdfe", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 17, 17, 48, 29, 289, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 17, 17, 48, 29, 289, DateTimeKind.Local).AddTicks(4180));
        }
    }
}
