using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class RemoveMetricTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Metrics_MetricsMetricId",
                table: "Sets");

            migrationBuilder.DropTable(
                name: "Metrics");

            migrationBuilder.DropIndex(
                name: "IX_Sets_MetricsMetricId",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "MetricsMetricId",
                table: "Sets");

            migrationBuilder.AddColumn<double>(
                name: "AverageOneRm",
                table: "Workouts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "IndexVal",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalVolume",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "OneRm",
                table: "Sets",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Volume",
                table: "Sets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageOneRm",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "IndexVal",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "TotalVolume",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "OneRm",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Sets");

            migrationBuilder.AddColumn<Guid>(
                name: "MetricsMetricId",
                table: "Sets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Metrics",
                columns: table => new
                {
                    MetricId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OneRm = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrics", x => x.MetricId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sets_MetricsMetricId",
                table: "Sets",
                column: "MetricsMetricId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_Metrics_MetricsMetricId",
                table: "Sets",
                column: "MetricsMetricId",
                principalTable: "Metrics",
                principalColumn: "MetricId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
