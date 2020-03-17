using Microsoft.EntityFrameworkCore.Migrations;

namespace ItechartProj.DAL.Migrations
{
    public partial class AddComents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                "Text",
                "News",
                "varchar(1000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<int>(
                "Viewers",
                "News",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                "Tag",
                table => new
                {
                    TagName = table.Column<string>(maxLength: 15),
                    NewsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagName);
                    table.ForeignKey(
                        "FK_Tag_Newss_NewsId",
                        x => x.NewsId,
                        "News",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Tag_NewsId",
                "Tag",
                "NewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Tag");

            migrationBuilder.DropColumn(
                "Viewers",
                "News");

            migrationBuilder.AlterColumn<string>(
                "Text",
                "News",
                "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)");
        }
    }
}