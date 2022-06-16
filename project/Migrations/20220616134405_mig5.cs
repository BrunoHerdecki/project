using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "TeacherId", "Name", "Password", "Surname", "Username" },
                values: new object[] { 1, "Albert", "12345", "Mark", "teacher1" });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "TeacherId", "Name", "Password", "Surname", "Username" },
                values: new object[] { 2, "Hubert", "12345", "Popcorn", "teacher2" });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "TeacherId", "Name", "Password", "Surname", "Username" },
                values: new object[] { 3, "Zygmunt", "12345", "Ogień", "teacher3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "teachers",
                keyColumn: "TeacherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "teachers",
                keyColumn: "TeacherId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "teachers",
                keyColumn: "TeacherId",
                keyValue: 3);
        }
    }
}
