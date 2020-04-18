using Microsoft.EntityFrameworkCore.Migrations;

namespace ItechartProj.DAL.Migrations
{
    public partial class AddJWT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Token",
                table => new
                {
                    Login = table.Column<string>(),
                    RefreshToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Login);
                    table.ForeignKey(
                        "FK_RefreshTokens_Users_Login",
                        x => x.Login,
                        "Users",
                        "Login",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Token");
        }
    }
}