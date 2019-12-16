using Microsoft.EntityFrameworkCore.Migrations;

namespace TidalMusicPlayer.Migrations
{
    public partial class UserData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Password", "Username" },
                values: new object[] { -1, "12345678", "andrewjobel" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: -1);
        }
    }
}
