using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class NewMeditationVitalityAndFastingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93ea1739-9efa-443a-951e-8f1891a67beb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f193d7e9-2b13-4297-8dd3-850534d30fba");

            migrationBuilder.CreateTable(
                name: "FastingPeriods",
                columns: table => new
                {
                    FastingPeriodId = table.Column<Guid>(nullable: false),
                    Started = table.Column<DateTime>(nullable: false),
                    Finished = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastingPeriods", x => x.FastingPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "MeditationLogs",
                columns: table => new
                {
                    MeditationLogId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: false),
                    Silence = table.Column<int>(nullable: false),
                    Willingness = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeditationLogs", x => x.MeditationLogId);
                });

            migrationBuilder.CreateTable(
                name: "VitalitySnapshots",
                columns: table => new
                {
                    VitalitySnapshotId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Mood = table.Column<int>(nullable: false),
                    Energy = table.Column<int>(nullable: false),
                    Focus = table.Column<int>(nullable: false),
                    Anxiety = table.Column<int>(nullable: false),
                    Fasted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalitySnapshots", x => x.VitalitySnapshotId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FastingPeriods");

            migrationBuilder.DropTable(
                name: "MeditationLogs");

            migrationBuilder.DropTable(
                name: "VitalitySnapshots");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "303e7197-111d-4485-aaa8-397ea37fa649");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3424af3f-2247-496e-8b09-740ee750107e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f193d7e9-2b13-4297-8dd3-850534d30fba", "4e108440-3864-4159-9448-03cad76b7419", "Superadmin", "SUPERADMIN" },
                    { "93ea1739-9efa-443a-951e-8f1891a67beb", "d3fdebb2-407e-42d9-a7c9-9e92419d80ac", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("6df3b21a-aaa8-43f3-9a62-ba0f244bc521"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 16, 15, 22, 38, 857, DateTimeKind.Local).AddTicks(8280));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: new Guid("ca6f4cb0-3d66-4041-b4f6-4208598f7571"),
                column: "CreatedAt",
                value: new DateTime(2020, 2, 16, 15, 22, 38, 857, DateTimeKind.Local).AddTicks(9970));
        }
    }
}
