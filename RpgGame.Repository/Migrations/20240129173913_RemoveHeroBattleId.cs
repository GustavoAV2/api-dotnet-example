using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgGame.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHeroBattleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "HeroesBattles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HeroesBattles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
