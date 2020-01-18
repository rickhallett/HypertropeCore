using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class ChangeExerciseTypeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Metrics_Sets_SetId",
                table: "Metrics");

            migrationBuilder.DropIndex(
                name: "IX_Metrics_SetId",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "SetId",
                table: "Metrics");

            migrationBuilder.AlterColumn<string>(
                name: "Exercise",
                table: "Sets",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Exercise",
                table: "Sets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SetId",
                table: "Metrics",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Metrics_SetId",
                table: "Metrics",
                column: "SetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Metrics_Sets_SetId",
                table: "Metrics",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "SetId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
