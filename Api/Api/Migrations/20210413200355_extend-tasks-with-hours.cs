using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class extendtaskswithhours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "ProjectTasks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hours",
                table: "ProjectTasks");
        }
    }
}
