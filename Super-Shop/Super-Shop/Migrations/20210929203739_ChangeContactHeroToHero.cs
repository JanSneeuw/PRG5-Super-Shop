using Microsoft.EntityFrameworkCore.Migrations;

namespace Super_Shop.Migrations
{
    public partial class ChangeContactHeroToHero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hero",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_HeroId",
                table: "Contacts",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Heroes_HeroId",
                table: "Contacts",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Heroes_HeroId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_HeroId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "Hero",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
