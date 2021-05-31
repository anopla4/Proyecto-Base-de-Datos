using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class _1 : Migration
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
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false),
                    img = table.Column<string>(nullable: true)
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
                    Current_TeamId = table.Column<Guid>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Year_Experience = table.Column<int>(nullable: false),
                    DeffAverage = table.Column<int>(nullable: false),
                    ERA = table.Column<int>(nullable: true),
                    Average = table.Column<int>(nullable: true),
                    img = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_Current_TeamId",
                        column: x => x.Current_TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PositionName = table.Column<string>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    PitcherWinerId = table.Column<Guid>(nullable: false),
                    PitcherLoserId = table.Column<Guid>(nullable: false),
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
                        name: "FK_Games_Players_PitcherLoserId",
                        column: x => x.PitcherLoserId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_PitcherWinerId",
                        column: x => x.PitcherWinerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_WinerTeamId",
                        column: x => x.WinerTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Series_SerieId_SerieInitDate_SerieEndDate",
                        columns: x => new { x.SerieId, x.SerieInitDate, x.SerieEndDate },
                        principalTable: "Series",
                        principalColumns: new[] { "Id", "InitDate", "EndDate" },
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StarPositionPlayersSeries",
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
                    table.PrimaryKey("PK_StarPositionPlayersSeries", x => new { x.SerieId, x.SerieInitDate, x.SerieEndDate, x.PositionId });
                    table.ForeignKey(
                        name: "FK_StarPositionPlayersSeries_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StarPositionPlayersSeries_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StarPositionPlayersSeries_Series_SerieId_SerieInitDate_SerieEndDate",
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
                    PositionId = table.Column<Guid>(nullable: false),
                    PlayerInId = table.Column<Guid>(nullable: false),
                    PlayerOutId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersChangesGames", x => new { x.GameGameId, x.PlayerInId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_PlayersChangesGames_Players_PlayerInId",
                        column: x => x.PlayerInId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersChangesGames_Players_PlayerOutId",
                        column: x => x.PlayerOutId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersChangesGames_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
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
                    PositionId = table.Column<Guid>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersGames", x => new { x.gameGameId, x.PlayerId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_PlayersGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersGames_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
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
                columns: new[] { "Id", "PlayerId", "PositionName" },
                values: new object[,]
                {
                    { new Guid("a18e810f-3533-4523-9ee3-ed60b8dc0617"), null, "C" },
                    { new Guid("936554d8-1e0c-40a3-9953-5e51f4e13d0c"), null, "1B" },
                    { new Guid("11440ccb-00ee-40e7-99c2-af8ae43f7cc6"), null, "2B" },
                    { new Guid("3bdcf06c-4b5b-4fe0-a0d3-5d66ff6d5344"), null, "3B" },
                    { new Guid("ece5db98-3593-4a88-8b69-89009f87a7d3"), null, "SS" },
                    { new Guid("0683f316-c01b-475f-8888-856a33725bdd"), null, "P" },
                    { new Guid("10b1cfac-3095-4813-abe4-55cf851878b7"), null, "LF" },
                    { new Guid("10d23c46-b623-48d0-a43e-832d89d9243e"), null, "RF" },
                    { new Guid("275e26ca-7373-4281-a900-a25d513cd8c5"), null, "CF" },
                    { new Guid("70055929-a66e-4af5-9db9-4af03efb60a9"), null, "BD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_LoserTeamId",
                table: "Games",
                column: "LoserTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PitcherLoserId",
                table: "Games",
                column: "PitcherLoserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PitcherWinerId",
                table: "Games",
                column: "PitcherWinerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinerTeamId",
                table: "Games",
                column: "WinerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_SerieId_SerieInitDate_SerieEndDate",
                table: "Games",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_Current_TeamId",
                table: "Players",
                column: "Current_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersChangesGames_PlayerInId",
                table: "PlayersChangesGames",
                column: "PlayerInId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersChangesGames_PlayerOutId",
                table: "PlayersChangesGames",
                column: "PlayerOutId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersChangesGames_PositionId",
                table: "PlayersChangesGames",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersChangesGames_GameGameId_GameWinerTeamId_GameLoserTeamId_GameGameDate_GameGameTime_GameSerieId_GameSerieInitDate_GameS~",
                table: "PlayersChangesGames",
                columns: new[] { "GameGameId", "GameWinerTeamId", "GameLoserTeamId", "GameGameDate", "GameGameTime", "GameSerieId", "GameSerieInitDate", "GameSerieEndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersGames_PlayerId",
                table: "PlayersGames",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersGames_PositionId",
                table: "PlayersGames",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersGames_gameGameId_gameWinerTeamId_gameLoserTeamId_gameGameDate_gameGameTime_gameSerieId_gameSerieInitDate_gameSerieEnd~",
                table: "PlayersGames",
                columns: new[] { "gameGameId", "gameWinerTeamId", "gameLoserTeamId", "gameGameDate", "gameGameTime", "gameSerieId", "gameSerieInitDate", "gameSerieEndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PlayerId",
                table: "Positions",
                column: "PlayerId");

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
                name: "IX_StarPositionPlayersSeries_PlayerId",
                table: "StarPositionPlayersSeries",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_StarPositionPlayersSeries_PositionId",
                table: "StarPositionPlayersSeries",
                column: "PositionId");

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
                name: "PlayersChangesGames");

            migrationBuilder.DropTable(
                name: "PlayersGames");

            migrationBuilder.DropTable(
                name: "StarPositionPlayersSeries");

            migrationBuilder.DropTable(
                name: "TeamsSeries");

            migrationBuilder.DropTable(
                name: "TeamsSeriesDirectors");

            migrationBuilder.DropTable(
                name: "TeamsSeriesPlayers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Caracters");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
