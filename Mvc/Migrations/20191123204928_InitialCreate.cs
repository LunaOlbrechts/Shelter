using Microsoft.EntityFrameworkCore.Migrations;

namespace Mvc.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    IsChecked = table.Column<bool>(nullable: false),
                    KidFriendly = table.Column<bool>(nullable: false),
                    Since = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
