using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_ITHoot.Migrations
{
    public partial class UpdateTableProjectUpdateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TimeOfProject",
                table: "Projects",
                type: "int",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(2,1)",
                oldMaxLength: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TimeOfProject",
                table: "Projects",
                type: "numeric(2,1)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2);
        }
    }
}
