using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class AddMetricsToSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MetricsMetricId",
                table: "Sets",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Metrics_MetricsMetricId",
                table: "Sets");

            migrationBuilder.DropIndex(
                name: "IX_Sets_MetricsMetricId",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "MetricsMetricId",
                table: "Sets");
        }
    }
}
