using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class AddUserIdToWorkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b5bb31f-9df6-49f2-810f-f3af4ba9bfda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56d521fa-f260-4b5c-ac9a-18649a1c1a17");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Workouts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Workouts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56d521fa-f260-4b5c-ac9a-18649a1c1a17", "46df01a5-398e-457c-84bf-7639db21386b", "Superadmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b5bb31f-9df6-49f2-810f-f3af4ba9bfda", "60960bb5-eced-4597-8519-a804660269c5", "User", "USER" });
        }
    }
}
