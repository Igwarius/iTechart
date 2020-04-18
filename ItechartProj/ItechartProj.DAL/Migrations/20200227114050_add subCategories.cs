using Microsoft.EntityFrameworkCore.Migrations;

namespace ItechartProj.DAL.Migrations
{
    public partial class addsubCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Tag");

            migrationBuilder.AlterColumn<string>(
                "Token",
                "Token",
                "varchar(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                "CategoryID",
                "News",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "SubCategoryId",
                "News",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                "Categories",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>()
                },
                constraints: table => { table.PrimaryKey("PK_Categories", x => x.Id); });

            migrationBuilder.CreateTable(
                "Comments",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    NewsId = table.Column<int>(),
                    Text = table.Column<string>("varchar(1000)"),
                    Likes = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        "FK_Comments_Newss_NewsId",
                        x => x.NewsId,
                        "News",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SubCategories",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(),
                    CategoryID = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        "FK_SubCategories_Categories_CategoryID",
                        x => x.CategoryID,
                        "Categories",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Newss_CategoryID",
                "News",
                "CategoryID");

            migrationBuilder.CreateIndex(
                "IX_Newss_SubCategoryId",
                "News",
                "SubCategoryId");

            migrationBuilder.CreateIndex(
                "IX_Comments_NewsId",
                "Comments",
                "NewsId");

            migrationBuilder.CreateIndex(
                "IX_SubCategories_CategoryID",
                "SubCategories",
                "CategoryID");

            migrationBuilder.AddForeignKey(
                "FK_Newss_Categories_CategoryID",
                "News",
                "CategoryID",
                "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Newss_SubCategories_SubCategoryId",
                "News",
                "SubCategoryId",
                "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Newss_Categories_CategoryID",
                "News");

            migrationBuilder.DropForeignKey(
                "FK_Newss_SubCategories_SubCategoryId",
                "News");

            migrationBuilder.DropTable(
                "Comments");

            migrationBuilder.DropTable(
                "SubCategories");

            migrationBuilder.DropTable(
                "Categories");

            migrationBuilder.DropIndex(
                "IX_Newss_CategoryID",
                "News");

            migrationBuilder.DropIndex(
                "IX_Newss_SubCategoryId",
                "News");

            migrationBuilder.DropColumn(
                "CategoryID",
                "News");

            migrationBuilder.DropColumn(
                "SubCategoryId",
                "News");

            migrationBuilder.AlterColumn<string>(
                "Token",
                "Token",
                "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                "Tag",
                table => new
                {
                    TagName = table.Column<string>("nvarchar(15)", maxLength: 15),
                    NewsId = table.Column<int>("int", nullable: true)
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
    }
}