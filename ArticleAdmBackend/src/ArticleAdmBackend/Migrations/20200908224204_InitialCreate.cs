using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NmAdminBackEnd.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AbbreviationName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    CreationDatetime = table.Column<DateTime>(nullable: false),
                    UpdateDatetime = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
