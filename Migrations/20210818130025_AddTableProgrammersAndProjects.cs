using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_ITHoot.Migrations
{
    public partial class AddTableProgrammersAndProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammersAndProjects",
                columns: table => new
                {
                    IdProgrammer = table.Column<int>(nullable: false),
                    IdProject = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammersAndProjects", x => new { x.IdProgrammer, x.IdProject });
                    table.ForeignKey(
                        name: "FK_ProgrammersAndProjects_Programmers_IdProgrammer",
                        column: x => x.IdProgrammer,
                        principalTable: "Programmers",
                        principalColumn: "IdProgrammer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgrammersAndProjects_Projects_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Projects",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammersAndProjects_IdProject",
                table: "ProgrammersAndProjects",
                column: "IdProject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammersAndProjects");
        }
    }
}
