using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class DefaultExerciseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95123ef0-342d-49a9-85eb-fa696c7ff4ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8592dc2-c269-4dc6-95e8-1d54878d2422");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "134a8a1d-1846-4055-8e26-3dcf1d11d422", "572260f1-2197-4a05-aed8-e4bbd8d50470", "Superadmin", "SUPERADMIN" },
                    { "1fcfc242-53a1-403e-9139-052a8af7ca40", "b5ee3b3f-35ee-45df-95bb-810978e9a555", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { new Guid("2e1449dc-b751-4bed-8dd2-4cf3fa186586"), "sq", "Squat" },
                    { new Guid("70aa3e53-9581-4c9d-8502-9cfed90786a3"), "bp", "Bench Press" },
                    { new Guid("70f3fa12-cdac-4efb-8d35-773c511e5df0"), "mp", "Military Press" },
                    { new Guid("32e7c0e8-a5f2-4fc8-bdb9-32ad8f5c70ac"), "dl", "Deadlift" },
                    { new Guid("e85442ca-6143-4a87-a87d-62d7c962308e"), "lr", "Leg Raise" },
                    { new Guid("a8cde4b5-343c-4881-bee3-1db3067e7feb"), "ur", "Upright Row" },
                    { new Guid("3b847791-2042-49c1-bec7-3fd99efef349"), "pu", "Pull up" },
                    { new Guid("6a62969b-2790-4d74-b1d5-2cb75bd59d3f"), "cu", "Chin Up" }
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 15, 18, 56, 45, 267, DateTimeKind.Local).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 15, 18, 56, 45, 267, DateTimeKind.Local).AddTicks(5940));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134a8a1d-1846-4055-8e26-3dcf1d11d422");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fcfc242-53a1-403e-9139-052a8af7ca40");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: new Guid("2e1449dc-b751-4bed-8dd2-4cf3fa186586"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: new Guid("32e7c0e8-a5f2-4fc8-bdb9-32ad8f5c70ac"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: new Guid("3b847791-2042-49c1-bec7-3fd99efef349"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: new Guid("6a62969b-2790-4d74-b1d5-2cb75bd59d3f"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: new Guid("70aa3e53-9581-4c9d-8502-9cfed90786a3"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: new Guid("70f3fa12-cdac-4efb-8d35-773c511e5df0"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: new Guid("a8cde4b5-343c-4881-bee3-1db3067e7feb"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: new Guid("e85442ca-6143-4a87-a87d-62d7c962308e"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95123ef0-342d-49a9-85eb-fa696c7ff4ba", "c478cdf7-5295-4764-84cf-ae20c52e61fc", "Superadmin", "SUPERADMIN" },
                    { "d8592dc2-c269-4dc6-95e8-1d54878d2422", "c7364235-545f-4cb0-9b0c-9717802f0350", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 15, 18, 54, 43, 396, DateTimeKind.Local).AddTicks(990));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 15, 18, 54, 43, 396, DateTimeKind.Local).AddTicks(2570));
        }
    }
}
