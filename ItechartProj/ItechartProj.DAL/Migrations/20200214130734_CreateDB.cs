using Microsoft.EntityFrameworkCore.Migrations;

namespace ItechartProj.DAL.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Login = table.Column<string>(maxLength: 15),
                    password = table.Column<string>(maxLength: 20)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Login); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Users");
        }
    }
}