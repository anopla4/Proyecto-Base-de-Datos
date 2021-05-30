using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class sdf : Migration
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
                    Year_Experience = table.Column<int>(nullable: false),
                    Average = table.Column<int>(nullable: false)
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
                    WinerId = table.Column<Guid>(nullable: true),
                    LoserId = table.Column<Guid>(nullable: true),
                    NumberOfGames = table.Column<int>(nullable: false),
                    NumberOfTeams = table.Column<int>(nullable: false)
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
                    WonGames = table.Column<int>(nullable: false),
                    LostGames = table.Column<int>(nullable: false),
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
                    GameId = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_Games", x => new { x.GameId, x.WinerTeamId, x.LoserTeamId, x.GameDate, x.GameTime, x.SerieId, x.SerieInitDate, x.SerieEndDate });
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
                name: "PitcherChangesGames",
                columns: table => new
                {
                    WinerTeamId = table.Column<Guid>(nullable: false),
                    LoserTeamId = table.Column<Guid>(nullable: false),
                    GameDate = table.Column<DateTime>(type: "date", nullable: false),
                    GameTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SerieId = table.Column<Guid>(nullable: false),
                    SerieInitDate = table.Column<DateTime>(nullable: false),
                    SerieEndDate = table.Column<DateTime>(nullable: false),
                    PitcherInPlayerId = table.Column<Guid>(nullable: false),
                    PitcherInPositionId = table.Column<Guid>(nullable: false),
                    PitcherOutPlayerId = table.Column<Guid>(nullable: false),
                    PitcherOutPositionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitcherChangesGames", x => new { x.GameTime, x.GameDate, x.SerieId, x.SerieInitDate, x.SerieEndDate, x.PitcherInPlayerId, x.PitcherInPositionId });
                    table.ForeignKey(
                        name: "FK_PitcherChangesGames_Teams_LoserTeamId",
                        column: x => x.LoserTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PitcherChangesGames_Teams_WinerTeamId",
                        column: x => x.WinerTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PitcherChangesGames_PositionPlayers_PitcherInPlayerId_PitcherInPositionId",
                        columns: x => new { x.PitcherInPlayerId, x.PitcherInPositionId },
                        principalTable: "PositionPlayers",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PitcherChangesGames_PositionPlayers_PitcherOutPlayerId_PitcherOutPositionId",
                        columns: x => new { x.PitcherOutPlayerId, x.PitcherOutPositionId },
                        principalTable: "PositionPlayers",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PitcherChangesGames_Series_SerieId_SerieInitDate_SerieEndDate",
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

            migrationBuilder.CreateTable(
                name: "PlayersChangesGames",
                columns: table => new
                {
                    GameGameId = table.Column<Guid>(nullable: false),
                    GameWinerTeamId = table.Column<Guid>(nullable: false),
                    GameLoserTeamId = table.Column<Guid>(nullable: false),
                    GameGameDate = table.Column<DateTime>(type: "date", nullable: false),
                    GameGameTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    GameSerieId = table.Column<Guid>(nullable: false),
                    GameSerieInitDate = table.Column<DateTime>(nullable: false),
                    GameSerieEndDate = table.Column<DateTime>(nullable: false),
                    PlayerInPlayerId = table.Column<Guid>(nullable: false),
                    PlayerInPositionId = table.Column<Guid>(nullable: false),
                    PlayerOutPlayerId = table.Column<Guid>(nullable: false),
                    PlayerOutPositionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersChangesGames", x => new { x.GameGameId, x.PlayerInPlayerId, x.PlayerInPositionId });
                    table.ForeignKey(
                        name: "FK_PlayersChangesGames_PositionPlayers_PlayerInPlayerId_PlayerInPositionId",
                        columns: x => new { x.PlayerInPlayerId, x.PlayerInPositionId },
                        principalTable: "PositionPlayers",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersChangesGames_PositionPlayers_PlayerOutPlayerId_PlayerOutPositionId",
                        columns: x => new { x.PlayerOutPlayerId, x.PlayerOutPositionId },
                        principalTable: "PositionPlayers",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersChangesGames_Games_GameGameId_GameWinerTeamId_GameLoserTeamId_GameGameDate_GameGameTime_GameSerieId_GameSerieInitDate~",
                        columns: x => new { x.GameGameId, x.GameWinerTeamId, x.GameLoserTeamId, x.GameGameDate, x.GameGameTime, x.GameSerieId, x.GameSerieInitDate, x.GameSerieEndDate },
                        principalTable: "Games",
                        principalColumns: new[] { "GameId", "WinerTeamId", "LoserTeamId", "GameDate", "GameTime", "SerieId", "SerieInitDate", "SerieEndDate" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersGames",
                columns: table => new
                {
                    gameGameId = table.Column<Guid>(nullable: false),
                    gameWinerTeamId = table.Column<Guid>(nullable: false),
                    gameLoserTeamId = table.Column<Guid>(nullable: false),
                    gameGameDate = table.Column<DateTime>(type: "date", nullable: false),
                    gameGameTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    gameSerieId = table.Column<Guid>(nullable: false),
                    gameSerieInitDate = table.Column<DateTime>(nullable: false),
                    gameSerieEndDate = table.Column<DateTime>(nullable: false),
                    PositionPlayerPlayerId = table.Column<Guid>(nullable: false),
                    PositionPlayerPositionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersGames", x => new { x.gameGameId, x.PositionPlayerPlayerId, x.PositionPlayerPositionId });
                    table.ForeignKey(
                        name: "FK_PlayersGames_PositionPlayers_PositionPlayerPlayerId_PositionPlayerPositionId",
                        columns: x => new { x.PositionPlayerPlayerId, x.PositionPlayerPositionId },
                        principalTable: "PositionPlayers",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersGames_Games_gameGameId_gameWinerTeamId_gameLoserTeamId_gameGameDate_gameGameTime_gameSerieId_gameSerieInitDate_gameSe~",
                        columns: x => new { x.gameGameId, x.gameWinerTeamId, x.gameLoserTeamId, x.gameGameDate, x.gameGameTime, x.gameSerieId, x.gameSerieInitDate, x.gameSerieEndDate },
                        principalTable: "Games",
                        principalColumns: new[] { "GameId", "WinerTeamId", "LoserTeamId", "GameDate", "GameTime", "SerieId", "SerieInitDate", "SerieEndDate" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PositionName" },
                values: new object[,]
                {
                    { new Guid("4fc0929e-f2c5-4602-a218-140f36f104e0"), "C" },
                    { new Guid("f224eeda-4975-4966-ad53-ad58f2bd43aa"), "1B" },
                    { new Guid("bcb3e963-44e8-4ca0-9034-9572fd7e5b44"), "2B" },
                    { new Guid("b7fcd5f9-fdcb-45f8-823f-29e7f794e42e"), "3B" },
                    { new Guid("7b8861f1-c056-49d9-9b06-c6ec2951e25a"), "SS" },
                    { new Guid("4bafc2a7-831e-46d6-8e7f-9f5c51036d02"), "P" },
                    { new Guid("f96693d7-e1f0-4df8-87d9-bbf8950d6dd8"), "LF" },
                    { new Guid("8225f8a0-7b5b-41f9-994c-c26ad3e861d6"), "RF" },
                    { new Guid("abbece16-557a-4d1a-b57e-8918d2b1330d"), "CF" },
                    { new Guid("6c4edec6-cf0c-4764-b415-d616ff742e45"), "BD" }
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
                name: "IX_PitcherChangesGames_LoserTeamId",
                table: "PitcherChangesGames",
                column: "LoserTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PitcherChangesGames_WinerTeamId",
                table: "PitcherChangesGames",
                column: "WinerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PitcherChangesGames_PitcherInPlayerId_PitcherInPositionId",
                table: "PitcherChangesGames",
                columns: new[] { "PitcherInPlayerId", "PitcherInPositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_PitcherChangesGames_PitcherOutPlayerId_PitcherOutPositionId",
                table: "PitcherChangesGames",
                columns: new[] { "PitcherOutPlayerId", "PitcherOutPositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_PitcherChangesGames_SerieId_SerieInitDate_SerieEndDate",
                table: "PitcherChangesGames",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_Current_TeamId",
                table: "Players",
                column: "Current_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersChangesGames_PlayerInPlayerId_PlayerInPositionId",
                table: "PlayersChangesGames",
                columns: new[] { "PlayerInPlayerId", "PlayerInPositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersChangesGames_PlayerOutPlayerId_PlayerOutPositionId",
                table: "PlayersChangesGames",
                columns: new[] { "PlayerOutPlayerId", "PlayerOutPositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersChangesGames_GameGameId_GameWinerTeamId_GameLoserTeamId_GameGameDate_GameGameTime_GameSerieId_GameSerieInitDate_GameS~",
                table: "PlayersChangesGames",
                columns: new[] { "GameGameId", "GameWinerTeamId", "GameLoserTeamId", "GameGameDate", "GameGameTime", "GameSerieId", "GameSerieInitDate", "GameSerieEndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersGames_PositionPlayerPlayerId_PositionPlayerPositionId",
                table: "PlayersGames",
                columns: new[] { "PositionPlayerPlayerId", "PositionPlayerPositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersGames_gameGameId_gameWinerTeamId_gameLoserTeamId_gameGameDate_gameGameTime_gameSerieId_gameSerieInitDate_gameSerieEnd~",
                table: "PlayersGames",
                columns: new[] { "gameGameId", "gameWinerTeamId", "gameLoserTeamId", "gameGameDate", "gameGameTime", "gameSerieId", "gameSerieInitDate", "gameSerieEndDate" });

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
                name: "PitcherChangesGames");

            migrationBuilder.DropTable(
                name: "PlayersChangesGames");

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
                name: "Games");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "PositionPlayers");

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
