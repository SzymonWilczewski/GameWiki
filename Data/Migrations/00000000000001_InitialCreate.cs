using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameWikiDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "City", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Stockholm", "Sweden", "Mojang AB" },
                    { 2, "Warsaw", "Poland", "CD Projekt Red" },
                    { 3, "Redwood City", "United States", "Electronic Arts" },
                    { 4, "Montreuil", "France", "Ubisoft" },
                    { 5, "Stockholm", "Sweden", "Avalanche Studios Group" },
                    { 6, "New York City", "United States", "Rockstar Games" },
                    { 7, "Warsaw", "Poland", "11 bit studios" },
                    { 8, "Rome", "Italy", "Kunos Simulazioni" },
                    { 9, "Santa Monica", "United States", "Activision" },
                    { 10, "Kyoto", "Japan", "Nintendo" },
                    { 11, "Cary", "United States", "Epic Games" },
                    { 12, "Stockholm", "Sweden", "Paradox Interactive" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "DeveloperId", "Genre", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 1, "Sandbox", "Minecraft", new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "RPG", "The Witcher 3: Wild Hunt", new DateTime(2015, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, "Racing", "Need for Speed: Most Wanted", new DateTime(2012, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, "Adventure", "Assassin's Creed Unity", new DateTime(2014, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, "Action", "Just Cause 3", new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, "Action", "Grand Theft Auto V", new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, "Survival", "Frostpunk", new DateTime(2018, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, "Racing", "Assetto Corsa", new DateTime(2014, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, "FPS", "Call of Duty: Advanced Warfare", new DateTime(2014, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, "Platformer", "Super Mario Bros.", new DateTime(1985, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 11, "Sports", "Rocket League", new DateTime(2015, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 12, "Simulation", "Cities: Skylines", new DateTime(2015, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 3, "FPS", "Battlefield 4", new DateTime(2013, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 6, "Action", "Red Dead Redemption 2", new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 3, "Simulation", "The Sims 3", new DateTime(2009, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 4, "Adventure", "Tom Clancy's The Division", new DateTime(2016, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 2, "RPG", "Cyberpunk 2077", new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 4, "FPS", "Far Cry 4", new DateTime(2014, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 3, "Action", "Mirror's Edge", new DateTime(2008, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 4, "Racing", "The Crew", new DateTime(2014, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                column: "DeveloperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Developers");
        }
    }
}
