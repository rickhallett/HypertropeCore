using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class AddUserIdToMeditationLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "303e7197-111d-4485-aaa8-397ea37fa649");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3424af3f-2247-496e-8b09-740ee750107e");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "MeditationLogs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48ca4891-5b88-4de4-aaac-f2661ca934f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f14a0375-397e-4c06-8dd9-f88d69b43423");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MeditationLogs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "303e7197-111d-4485-aaa8-397ea37fa649", "a5688dca-b3f8-4535-beb2-bcbd40dffc61", "Superadmin", "SUPERADMIN" },
                    { "3424af3f-2247-496e-8b09-740ee750107e", "1aa1e259-3854-47bd-ae72-9f3d27be709d", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 16, 17, 21, 2, 955, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 16, 17, 21, 2, 955, DateTimeKind.Local).AddTicks(1810));
        }
    }
}
