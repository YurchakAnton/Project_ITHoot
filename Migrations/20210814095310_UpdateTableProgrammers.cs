using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_ITHoot.Migrations
{
    public partial class UpdateTableProgrammers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Programmers");

            migrationBuilder.DropColumn(
                name: "Project",
                table: "Programmers");

            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "Programmers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Programmers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Programmers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Programmers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Programmers");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Programmers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Programmers",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Project",
                table: "Programmers",
                type: "nvarchar(20)",
                nullable: true);
        }
    }
}
