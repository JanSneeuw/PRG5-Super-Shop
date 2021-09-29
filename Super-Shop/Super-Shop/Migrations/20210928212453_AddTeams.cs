using Microsoft.EntityFrameworkCore.Migrations;

namespace Super_Shop.Migrations
{
    public partial class AddTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Teams_TeamId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_TeamId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Heroes");

            migrationBuilder.CreateTable(
                name: "HeroTeam",
                columns: table => new
                {
                    MembersId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroTeam", x => new { x.MembersId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_HeroTeam_Heroes_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroTeam_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroTeam_TeamsId",
                table: "HeroTeam",
                column: "TeamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroTeam");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_TeamId",
                table: "Heroes",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Teams_TeamId",
                table: "Heroes",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
