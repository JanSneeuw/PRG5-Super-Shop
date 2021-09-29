using Microsoft.EntityFrameworkCore.Migrations;

namespace Super_Shop.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PowerLevel = table.Column<int>(type: "int", nullable: false),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "ImageUri", "Name", "Role" },
                values: new object[,]
                {
                    { -1, "~/img/employees/eric.jfif", "Eric Kuijpers", "CEO" },
                    { -2, "~/img/employees/carron.jfif", "Carron Schilders", "CTO" },
                    { -3, "~/img/employees/stijn.jfif", "Stijn Smulders", "Service desk" }
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "ImageUri", "Name", "PowerLevel", "TeamId" },
                values: new object[,]
                {
                    { 1, "~/img/iron_man.png", "Iron Man", 9001, null },
                    { 2, "~/img/kermit.png", "Kermit the frog", 5, null },
                    { 3, "~/img/batman.png", "Batman", 1, null },
                    { 4, "~/img/deadpool.png", "Deadpool", 200, null },
                    { 5, "~/img/wolverine.png", "Wolverine", 150, null }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "ImageUri", "Name" },
                values: new object[,]
                {
                    { 1, "", "The dream team" },
                    { 3, "", "Dharma Initiative" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_TeamId",
                table: "Heroes",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
