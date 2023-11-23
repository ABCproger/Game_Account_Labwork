﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Account_Labwork.Migrations
{
    /// <inheritdoc />
    public partial class update_Games_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstPlayer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondPlayer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWin = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    GameAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_GameAccounts_GameAccountId",
                        column: x => x.GameAccountId,
                        principalTable: "GameAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameAccountId",
                table: "Game",
                column: "GameAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
