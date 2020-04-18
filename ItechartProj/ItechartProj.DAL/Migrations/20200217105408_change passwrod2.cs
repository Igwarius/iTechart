using Microsoft.EntityFrameworkCore.Migrations;

namespace ItechartProj.DAL.Migrations
{
    public partial class changepasswrod2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "Password",
                "Users",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "Password",
                "Users",
                "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 600);
        }
    }
}