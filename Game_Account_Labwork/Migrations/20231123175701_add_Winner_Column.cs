using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Account_Labwork.Migrations
{
    /// <inheritdoc />
    public partial class add_Winner_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWin",
                table: "Game");

            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "Game",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Game");

            migrationBuilder.AddColumn<bool>(
                name: "IsWin",
                table: "Game",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
