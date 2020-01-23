using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class TrackingToSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a2b9f2f-0d1c-4041-ae01-e26bbc3c17fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9dd8ce0-84db-49e3-8028-0ab282a19e24");

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("23aa0987-e57b-4cf4-9c9e-456d9e92e9b5"));

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("27b3f47d-7cf6-4d1e-91b1-24df3889cb17"));

            migrationBuilder.AddColumn<bool>(
                name: "Tracking",
                table: "Sets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b60ea35-36cb-466c-9a32-d1c59149a797", "7695fc2f-0439-40f5-9b46-781ef7469bcd", "Superadmin", "SUPERADMIN" },
                    { "6bca4677-dedb-488d-b8f9-db78a6f9f1cc", "1c37111a-f65c-47ca-ab59-b8f0d6c14123", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "Body", "CreatedAt" },
                values: new object[,]
                {
                    { new Guid("4aff8c4d-7184-4b66-94f0-7c87f76298ff"), "Bruce Lee", "I fear not the man who has practiced 10,000 kicks once, but I fear the man who has practiced one kick 10,000 times.", new DateTime(2020, 1, 23, 8, 23, 36, 216, DateTimeKind.Local).AddTicks(93) },
                    { new Guid("2a9ba60c-ce52-47a9-965e-09f2080e48fb"), "Bruce Lee", "The successful warrior is the average man, with laser-like focus", new DateTime(2020, 1, 23, 8, 23, 36, 218, DateTimeKind.Local).AddTicks(5705) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bca4677-dedb-488d-b8f9-db78a6f9f1cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b60ea35-36cb-466c-9a32-d1c59149a797");

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("2a9ba60c-ce52-47a9-965e-09f2080e48fb"));

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("4aff8c4d-7184-4b66-94f0-7c87f76298ff"));

            migrationBuilder.DropColumn(
                name: "Tracking",
                table: "Sets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a2b9f2f-0d1c-4041-ae01-e26bbc3c17fd", "e50fc696-c7a7-4fbe-b0ba-fe4a6a12ca41", "Superadmin", "SUPERADMIN" },
                    { "a9dd8ce0-84db-49e3-8028-0ab282a19e24", "4336c7b0-2067-4f37-a553-3e9c70f6c1f0", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "Body", "CreatedAt" },
                values: new object[,]
                {
                    { new Guid("27b3f47d-7cf6-4d1e-91b1-24df3889cb17"), "Bruce Lee", "I fear not the man who has practiced 10,000 kicks once, but I fear the man who has practiced one kick 10,000 times.", new DateTime(2020, 1, 21, 7, 48, 3, 966, DateTimeKind.Local).AddTicks(829) },
                    { new Guid("23aa0987-e57b-4cf4-9c9e-456d9e92e9b5"), "Bruce Lee", "The successful warrior is the average man, with laser-like focus", new DateTime(2020, 1, 21, 7, 48, 3, 968, DateTimeKind.Local).AddTicks(5288) }
                });
        }
    }
}
