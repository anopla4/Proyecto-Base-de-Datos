using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caracters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Caracter_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    Day = table.Column<string>(nullable: false),
                    Hour = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => new { x.Day, x.Hour });
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PositionName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Current_TeamId = table.Column<Guid>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Year_Experience = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_Current_TeamId",
                        column: x => x.Current_TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InitDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CaracterId = table.Column<Guid>(nullable: false),
                    WinerId = table.Column<Guid>(nullable: false),
                    LoserId = table.Column<Guid>(nullable: false),
                    NumberOfGames = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => new { x.Id, x.InitDate, x.EndDate });
                    table.ForeignKey(
                        name: "FK_Series_Caracters_CaracterId",
                        column: x => x.CaracterId,
                        principalTable: "Caracters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Series_Teams_LoserId",
                        column: x => x.LoserId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Series_Teams_WinerId",
                        column: x => x.WinerId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PositionPlayers",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false),
                    Position_Average = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ERA = table.Column<double>(nullable: true),
                    Hand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionPlayers", x => new { x.PlayerId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_PositionPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionPlayers_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamsSeries",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(nullable: false),
                    SerieId = table.Column<Guid>(nullable: false),
                    SerieInitDate = table.Column<DateTime>(nullable: false),
                    SerieEndDate = table.Column<DateTime>(nullable: false),
                    WinnerGames = table.Column<int>(nullable: false),
                    LosserGames = table.Column<int>(nullable: false),
                    FinalPosition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsSeries", x => new { x.TeamId, x.SerieId, x.SerieInitDate, x.SerieEndDate });
                    table.ForeignKey(
                        name: "FK_TeamsSeries_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamsSeries_Series_SerieId_SerieInitDate_SerieEndDate",
                        columns: x => new { x.SerieId, x.SerieInitDate, x.SerieEndDate },
                        principalTable: "Series",
                        principalColumns: new[] { "Id", "InitDate", "EndDate" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamsSeriesDirectors",
                columns: table => new
                {
                    DirectorId = table.Column<Guid>(nullable: false),
                    SerieId = table.Column<Guid>(nullable: false),
                    SerieInitDate = table.Column<DateTime>(nullable: false),
                    SerieEndDate = table.Column<DateTime>(nullable: false),
                    TeamSerieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsSeriesDirectors", x => new { x.DirectorId, x.SerieId, x.SerieInitDate, x.SerieEndDate });
                    table.ForeignKey(
                        name: "FK_TeamsSeriesDirectors_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamsSeriesDirectors_Teams_TeamSerieId",
                        column: x => x.TeamSerieId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamsSeriesDirectors_Series_SerieId_SerieInitDate_SerieEndDate",
                        columns: x => new { x.SerieId, x.SerieInitDate, x.SerieEndDate },
                        principalTable: "Series",
                        principalColumns: new[] { "Id", "InitDate", "EndDate" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamsSeriesPlayers",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(nullable: false),
                    SerieId = table.Column<Guid>(nullable: false),
                    SerieInitDate = table.Column<DateTime>(nullable: false),
                    SerieEndDate = table.Column<DateTime>(nullable: false),
                    TeamSerieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsSeriesPlayers", x => new { x.PlayerId, x.SerieId, x.SerieInitDate, x.SerieEndDate });
                    table.ForeignKey(
                        name: "FK_TeamsSeriesPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamsSeriesPlayers_Teams_TeamSerieId",
                        column: x => x.TeamSerieId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamsSeriesPlayers_Series_SerieId_SerieInitDate_SerieEndDate",
                        columns: x => new { x.SerieId, x.SerieInitDate, x.SerieEndDate },
                        principalTable: "Series",
                        principalColumns: new[] { "Id", "InitDate", "EndDate" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    WinerTeamId = table.Column<Guid>(nullable: false),
                    LoserTeamId = table.Column<Guid>(nullable: false),
                    GameDate = table.Column<DateTime>(type: "date", nullable: false),
                    GameTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SerieId = table.Column<Guid>(nullable: false),
                    SerieInitDate = table.Column<DateTime>(nullable: false),
                    SerieEndDate = table.Column<DateTime>(nullable: false),
                    PitcherWinerPlayerId = table.Column<Guid>(nullable: false),
                    PitcherWinerPositionId = table.Column<Guid>(nullable: false),
                    PitcherLoserPlayerId = table.Column<Guid>(nullable: false),
                    PitcherLoserPositionId = table.Column<Guid>(nullable: false),
                    InFavorCarrers = table.Column<int>(nullable: false),
                    AgaintsCarrers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => new { x.GameTime, x.GameDate, x.SerieId, x.SerieInitDate, x.SerieEndDate });
                    table.ForeignKey(
                        name: "FK_Games_Teams_LoserTeamId",
                        column: x => x.LoserTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_WinerTeamId",
                        column: x => x.WinerTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_PositionPlayers_PitcherLoserPlayerId_PitcherLoserPositionId",
                        columns: x => new { x.PitcherLoserPlayerId, x.PitcherLoserPositionId },
                        principalTable: "PositionPlayers",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_PositionPlayers_PitcherWinerPlayerId_PitcherWinerPositionId",
                        columns: x => new { x.PitcherWinerPlayerId, x.PitcherWinerPositionId },
                        principalTable: "PositionPlayers",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Series_SerieId_SerieInitDate_SerieEndDate",
                        columns: x => new { x.SerieId, x.SerieInitDate, x.SerieEndDate },
                        principalTable: "Series",
                        principalColumns: new[] { "Id", "InitDate", "EndDate" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersGames",
                columns: table => new
                {
                    WinerTeamId = table.Column<Guid>(nullable: false),
                    LoserTeamId = table.Column<Guid>(nullable: false),
                    GameDate = table.Column<DateTime>(type: "date", nullable: false),
                    GameTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SerieId = table.Column<Guid>(nullable: false),
                    SerieInitDate = table.Column<DateTime>(nullable: false),
                    SerieEndDate = table.Column<DateTime>(nullable: false),
                    PositionPlayerPlayerId = table.Column<Guid>(nullable: false),
                    PositionPlayerPositionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersGames", x => new { x.GameTime, x.GameDate, x.SerieId, x.SerieInitDate, x.SerieEndDate, x.PositionPlayerPlayerId, x.PositionPlayerPositionId });
                    table.ForeignKey(
                        name: "FK_PlayersGames_Teams_LoserTeamId",
                        column: x => x.LoserTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersGames_Teams_WinerTeamId",
                        column: x => x.WinerTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersGames_PositionPlayers_PositionPlayerPlayerId_PositionPlayerPositionId",
                        columns: x => new { x.PositionPlayerPlayerId, x.PositionPlayerPositionId },
                        principalTable: "PositionPlayers",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersGames_Series_SerieId_SerieInitDate_SerieEndDate",
                        columns: x => new { x.SerieId, x.SerieInitDate, x.SerieEndDate },
                        principalTable: "Series",
                        principalColumns: new[] { "Id", "InitDate", "EndDate" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StartPositionPlayersSeries",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false),
                    SerieId = table.Column<Guid>(nullable: false),
                    SerieInitDate = table.Column<DateTime>(nullable: false),
                    SerieEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartPositionPlayersSeries", x => new { x.PositionId, x.SerieId, x.SerieInitDate, x.SerieEndDate });
                    table.ForeignKey(
                        name: "FK_StartPositionPlayersSeries_PositionPlayers_PlayerId_PositionId",
                        columns: x => new { x.PlayerId, x.PositionId },
                        principalTable: "PositionPlayers",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StartPositionPlayersSeries_Series_SerieId_SerieInitDate_SerieEndDate",
                        columns: x => new { x.SerieId, x.SerieInitDate, x.SerieEndDate },
                        principalTable: "Series",
                        principalColumns: new[] { "Id", "InitDate", "EndDate" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PositionName" },
                values: new object[,]
                {
                    { new Guid("5212e411-7cd7-494f-9c18-1af659dbcc78"), "C" },
                    { new Guid("1c323e07-77d8-4043-bfbe-bbb92437dd03"), "1B" },
                    { new Guid("d89c2e9c-3b71-4633-ad9f-ee7f7514a4d8"), "2B" },
                    { new Guid("3a7e4c3b-a2a6-44ba-ac92-eef8cfc8d392"), "3B" },
                    { new Guid("69627233-8b2a-42a2-b7d2-50591f4da2aa"), "SS" },
                    { new Guid("b28992f5-b3ce-4d08-9507-4daa84f2335c"), "P" },
                    { new Guid("def6c1b2-0bc0-4481-8578-70736cbe45b9"), "LF" },
                    { new Guid("99c3259d-e432-484e-b5df-4f6663b5ec3f"), "RF" },
                    { new Guid("5d8ec263-bab7-43ba-b75c-78d050236347"), "CF" },
                    { new Guid("be46fca2-9d4a-4e77-865e-e4e3c732714f"), "BD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_LoserTeamId",
                table: "Games",
                column: "LoserTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinerTeamId",
                table: "Games",
                column: "WinerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PitcherLoserPlayerId_PitcherLoserPositionId",
                table: "Games",
                columns: new[] { "PitcherLoserPlayerId", "PitcherLoserPositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_PitcherWinerPlayerId_PitcherWinerPositionId",
                table: "Games",
                columns: new[] { "PitcherWinerPlayerId", "PitcherWinerPositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_SerieId_SerieInitDate_SerieEndDate",
                table: "Games",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_Current_TeamId",
                table: "Players",
                column: "Current_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersGames_LoserTeamId",
                table: "PlayersGames",
                column: "LoserTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersGames_WinerTeamId",
                table: "PlayersGames",
                column: "WinerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersGames_PositionPlayerPlayerId_PositionPlayerPositionId",
                table: "PlayersGames",
                columns: new[] { "PositionPlayerPlayerId", "PositionPlayerPositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersGames_SerieId_SerieInitDate_SerieEndDate",
                table: "PlayersGames",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_PositionPlayers_PositionId",
                table: "PositionPlayers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_CaracterId",
                table: "Series",
                column: "CaracterId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_LoserId",
                table: "Series",
                column: "LoserId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_WinerId",
                table: "Series",
                column: "WinerId");

            migrationBuilder.CreateIndex(
                name: "IX_StartPositionPlayersSeries_PlayerId_PositionId",
                table: "StartPositionPlayersSeries",
                columns: new[] { "PlayerId", "PositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_StartPositionPlayersSeries_SerieId_SerieInitDate_SerieEndDate",
                table: "StartPositionPlayersSeries",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamsSeries_SerieId_SerieInitDate_SerieEndDate",
                table: "TeamsSeries",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamsSeriesDirectors_TeamSerieId",
                table: "TeamsSeriesDirectors",
                column: "TeamSerieId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsSeriesDirectors_SerieId_SerieInitDate_SerieEndDate",
                table: "TeamsSeriesDirectors",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamsSeriesPlayers_TeamSerieId",
                table: "TeamsSeriesPlayers",
                column: "TeamSerieId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsSeriesPlayers_SerieId_SerieInitDate_SerieEndDate",
                table: "TeamsSeriesPlayers",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "PlayersGames");

            migrationBuilder.DropTable(
                name: "StartPositionPlayersSeries");

            migrationBuilder.DropTable(
                name: "TeamsSeries");

            migrationBuilder.DropTable(
                name: "TeamsSeriesDirectors");

            migrationBuilder.DropTable(
                name: "TeamsSeriesPlayers");

            migrationBuilder.DropTable(
                name: "PositionPlayers");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Caracters");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
