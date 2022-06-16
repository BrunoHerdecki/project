using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_courses_CourseName",
                table: "courses",
                column: "CourseName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_courses_CourseName",
                table: "courses");
        }
    }
}
