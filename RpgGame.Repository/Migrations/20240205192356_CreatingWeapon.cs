using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgGame.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreatingWeapon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "HeroId",
                table: "Weapons",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_HeroId",
                table: "Weapons",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_HeroId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Weapons");
        }
    }
}
