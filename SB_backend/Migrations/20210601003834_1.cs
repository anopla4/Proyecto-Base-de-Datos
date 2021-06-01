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
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ImgPath = table.Column<string>(nullable: true)
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
                    Initials = table.Column<string>(nullable: false),
                    ImgPath = table.Column<string>(nullable: true)
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
                    Hand = table.Column<int>(nullable: true),
                    ImgPath = table.Column<string>(nullable: true)
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
                name: "PlayerPosition",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPosition", x => new { x.PlayerId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_PlayerPosition_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPosition_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
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
                    GameTime = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_Games", x => x.GameId);
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
                    TeamId = table.Column<Guid>(nullable: false)
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
                        name: "FK_TeamsSeriesPlayers_Teams_TeamId",
                        column: x => x.TeamId,
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
                        name: "FK_StarPositionPlayersSeries_PlayerPosition_PlayerId_PositionId",
                        columns: x => new { x.PlayerId, x.PositionId },
                        principalTable: "PlayerPosition",
                        principalColumns: new[] { "PlayerId", "PositionId" },
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
                    GameId = table.Column<Guid>(nullable: false),
                    PlayerIdIn = table.Column<Guid>(nullable: false),
                    PositionIdIn = table.Column<Guid>(nullable: false),
                    PlayerIdOut = table.Column<Guid>(nullable: false),
                    PositionIdOut = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersChangesGames", x => new { x.GameId, x.PlayerIdIn, x.PlayerIdOut });
                    table.ForeignKey(
                        name: "FK_PlayersChangesGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersChangesGames_PlayerPosition_PlayerIdIn_PositionIdIn",
                        columns: x => new { x.PlayerIdIn, x.PositionIdIn },
                        principalTable: "PlayerPosition",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersChangesGames_PlayerPosition_PlayerIdOut_PositionIdOut",
                        columns: x => new { x.PlayerIdOut, x.PositionIdOut },
                        principalTable: "PlayerPosition",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersGames",
                columns: table => new
                {
                    GameId = table.Column<Guid>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersGames", x => new { x.GameId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_PlayersGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PositionName" },
                values: new object[,]
                {
                    { new Guid("57cbcda7-cbac-42b5-bc0e-c71eb8540e27"), "C" },
                    { new Guid("a8660d61-d848-4a78-a41a-ea9c35d3f033"), "1B" },
                    { new Guid("ca2cc279-8a1d-49d2-bdc0-61c2c553e216"), "2B" },
                    { new Guid("f46b6571-8827-4736-b19f-d642fb7bf908"), "3B" },
                    { new Guid("8e66be38-216d-4874-a8d1-26465e853000"), "SS" },
                    { new Guid("bdcd2534-1ba3-4bd0-9099-13c6a0a9de41"), "P" },
                    { new Guid("0156a2e6-b9fe-43d8-9f68-012251df9e92"), "LF" },
                    { new Guid("04a2cadc-4608-4a96-8f55-b4ceb793f51b"), "RF" },
                    { new Guid("c548fdc4-de7f-43c4-97fb-131e8234958b"), "CF" },
                    { new Guid("13505c5f-d380-4cd0-9d58-fca642491f81"), "BD" }
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
                name: "IX_PlayerPosition_PositionId",
                table: "PlayerPosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Current_TeamId",
                table: "Players",
                column: "Current_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersChangesGames_PlayerIdIn_PositionIdIn",
                table: "PlayersChangesGames",
                columns: new[] { "PlayerIdIn", "PositionIdIn" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersChangesGames_PlayerIdOut_PositionIdOut",
                table: "PlayersChangesGames",
                columns: new[] { "PlayerIdOut", "PositionIdOut" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersGames_PlayerId",
                table: "PlayersGames",
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
                name: "IX_StarPositionPlayersSeries_PlayerId_PositionId",
                table: "StarPositionPlayersSeries",
                columns: new[] { "PlayerId", "PositionId" });

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
                name: "IX_TeamsSeriesPlayers_TeamId",
                table: "TeamsSeriesPlayers",
                column: "TeamId");

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
                name: "PlayerPosition");

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
