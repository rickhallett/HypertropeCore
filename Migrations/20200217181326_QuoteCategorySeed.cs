using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class QuoteCategorySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "8c0560c1-0608-4d03-998f-358ea605c1ff", "fce10f3d-9f67-4f69-aca3-5f5e9d3b9a66", "Superadmin", "SUPERADMIN" },
                    { "7b53fb08-e28e-4f3d-977b-7836141af512", "fd6a9c50-5318-4596-bc94-0e5d5e43d126", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "QuoteCategories",
                columns: new[] { "QuoteCategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("a00701ef-e319-4912-a10c-a2dfe5f53711"), "Motivational" },
                    { new Guid("c5e344c7-ec21-4a75-bcc8-46ff9c638f42"), "Profound" }
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 17, 18, 13, 24, 485, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 17, 18, 13, 24, 486, DateTimeKind.Local).AddTicks(120));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b53fb08-e28e-4f3d-977b-7836141af512");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c0560c1-0608-4d03-998f-358ea605c1ff");

            migrationBuilder.DeleteData(
                table: "QuoteCategories",
                keyColumn: "QuoteCategoryId",
                keyValue: new Guid("c5e344c7-ec21-4a75-bcc8-46ff9c638f42"));

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"));

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"));

            migrationBuilder.DeleteData(
                table: "QuoteCategories",
                keyColumn: "QuoteCategoryId",
                keyValue: new Guid("a00701ef-e319-4912-a10c-a2dfe5f53711"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35815486-38d6-4af0-927c-5bcf1f3439c5", "03c96baa-57b6-4f7d-bdf3-a35bbdf3dba5", "Superadmin", "SUPERADMIN" },
                    { "083f87b8-3742-400b-bcfd-78e35555c1e1", "e24ac6e7-9e51-4404-b5b6-a2f8bc73c2c7", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "Body", "CreatedAt", "QuoteCategoryId" },
                values: new object[,]
                {
                    { new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"), "Bruce Lee", "The successful warrior is the average man, with laser-like focus", new DateTime(2020, 2, 17, 18, 11, 19, 981, DateTimeKind.Local).AddTicks(160), new Guid("a00701ef-e319-4912-a10c-a2dfe5f53711") },
                    { new Guid("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"), "Bruce Lee", "I fear not the man who has practiced 10,000 kicks once, but I fear the man who has practiced one kick 10,000 times.", new DateTime(2020, 2, 17, 18, 11, 19, 980, DateTimeKind.Local).AddTicks(7480), new Guid("a00701ef-e319-4912-a10c-a2dfe5f53711") }
                });
        }
    }
}
