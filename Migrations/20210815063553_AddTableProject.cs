using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_ITHoot.Migrations
{
    public partial class AddTableProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfProject = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TimeOfProject = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
