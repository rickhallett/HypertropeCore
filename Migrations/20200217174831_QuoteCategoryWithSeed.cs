using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class QuoteCategoryWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48ca4891-5b88-4de4-aaac-f2661ca934f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f14a0375-397e-4c06-8dd9-f88d69b43423");

            migrationBuilder.AddColumn<Guid>(
                name: "QuoteCategoryId",
                table: "Quotes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "QuoteCategories",
                columns: table => new
                {
                    QuoteCategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteCategories", x => x.QuoteCategoryId);
                });

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
                columns: new[] { "CreatedAt", "QuoteCategoryId" },
                values: new object[] { new DateTime(2020, 2, 17, 17, 48, 29, 289, DateTimeKind.Local).AddTicks(2070), new Guid("a00701ef-e319-4912-a10c-a2dfe5f53711") });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"),
                columns: new[] { "CreatedAt", "QuoteCategoryId" },
                values: new object[] { new DateTime(2020, 2, 17, 17, 48, 29, 289, DateTimeKind.Local).AddTicks(4180), new Guid("a00701ef-e319-4912-a10c-a2dfe5f53711") });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuoteCategoryId",
                table: "Quotes",
                column: "QuoteCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteCategories_QuoteCategoryId",
                table: "Quotes",
                column: "QuoteCategoryId",
                principalTable: "QuoteCategories",
                principalColumn: "QuoteCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteCategories_QuoteCategoryId",
                table: "Quotes");

            migrationBuilder.DropTable(
                name: "QuoteCategories");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_QuoteCategoryId",
                table: "Quotes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38ed5e70-d274-4249-b932-5773f0a7d0d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ed0c694-edd4-4f0f-b126-c4a0ba733836");

            migrationBuilder.DropColumn(
                name: "QuoteCategoryId",
                table: "Quotes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48ca4891-5b88-4de4-aaac-f2661ca934f3", "28f049e1-507b-491c-a75e-f70051be6010", "Superadmin", "SUPERADMIN" },
                    { "f14a0375-397e-4c06-8dd9-f88d69b43423", "5df69d3b-67de-45aa-af81-4776993474f8", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 16, 17, 41, 59, 88, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 16, 17, 41, 59, 88, DateTimeKind.Local).AddTicks(1980));
        }
    }
}
