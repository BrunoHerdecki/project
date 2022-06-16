using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_participants",
                table: "participants",
                columns: new[] { "CourseId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_participants",
                table: "participants");
        }
    }
}
