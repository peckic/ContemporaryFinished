using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProjectIzzy.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanceMoves",
                columns: table => new
                {
                    MoveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    MusicType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdealTempo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanceMoves", x => x.MoveId);
                });

            migrationBuilder.CreateTable(
                name: "NatureTrail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrailName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailLength = table.Column<double>(type: "float", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WildLifeSightings = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureTrail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollegeProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearInProgram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "VideoGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGame", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DanceMoves",
                columns: new[] { "MoveId", "Difficulty", "IdealTempo", "MusicType", "Style" },
                values: new object[,]
                {
                    { 1, 3, 95, "Urban Beat", "Hip Hop" },
                    { 2, 4, 180, "Latin", "Salsa" }
                });

            migrationBuilder.InsertData(
                table: "NatureTrail",
                columns: new[] { "Id", "DifficultyLevel", "TrailLength", "TrailName", "WildLifeSightings" },
                values: new object[,]
                {
                    { 1, "Moderate", 4.7000000000000002, "Pine Ridge Loop", "Deer, red foxes, woodpeckers" },
                    { 2, "Hard", 9.3000000000000007, "Eagle Summit Trail", "Eagles, mountain goats, marmots" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "MemberId", "BirthDate", "CollegeProgram", "MemberName", "YearInProgram" },
                values: new object[,]
                {
                    { 1, new DateTime(2006, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Development", "Isabelle Peck", "Third year" },
                    { 2, new DateTime(2006, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Development", "Ethan Zins", "Second Year" }
                });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "Developer", "Genre", "Platform", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Nintendo", "Action-Adventure", "Nintendo Switch", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda: Tears of the Kingdom" },
                    { 2, "FromSoftware", "Action RPG", "PC / PlayStation / Xbox", new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elden Ring" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanceMoves");

            migrationBuilder.DropTable(
                name: "NatureTrail");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "VideoGame");
        }
    }
}
