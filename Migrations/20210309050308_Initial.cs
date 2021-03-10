using Microsoft.EntityFrameworkCore.Migrations;

namespace BookSeller.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorFirst = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorLast = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorMid = table.Column<string>(type: "TEXT", nullable: true),
                    Publisher = table.Column<string>(type: "TEXT", nullable: false),
                    ISBN = table.Column<long>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Classification = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    PageNum = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
