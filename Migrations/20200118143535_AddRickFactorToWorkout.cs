using Microsoft.EntityFrameworkCore.Migrations;

namespace HypertropeCore.Migrations
{
    public partial class AddRickFactorToWorkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndexVal",
                table: "Workouts");

            migrationBuilder.AddColumn<double>(
                name: "RickFactor",
                table: "Workouts",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RickFactor",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "IndexVal",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
