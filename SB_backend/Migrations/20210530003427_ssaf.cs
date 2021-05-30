using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class ssaf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("1c1ed8c3-d023-4bca-9ae4-b5d3efda30d9"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("27ff8b46-e00b-47a4-bd1e-989c7896fb9e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("3b05a7c8-f0b5-4006-a447-ec080eeee51d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("597fe1a4-236f-4c8a-b1d2-3f6d0bb21be9"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6cfa519e-dc6a-42c5-96a0-8b48aa58b84e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("7209556c-1887-465a-a7e4-5ec6d8eddf50"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("9d3c268e-d2c6-41a3-839d-bfc0e7ebb6b7"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("bdbcc356-36e3-4b57-9a5f-405cec9c475a"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f6c693ca-9af3-4464-9549-61452dc5cb66"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("fddc8276-76ad-4dd2-89cc-dfe20a2dcdf7"));

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

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PositionName" },
                values: new object[,]
                {
                    { new Guid("a3ebf1ed-141f-4e33-a745-71535b046afb"), "C" },
                    { new Guid("0b2f472a-f4b5-45fe-8236-82c94e6ac945"), "1B" },
                    { new Guid("6128334e-197f-41c6-b92d-27dfde1ba609"), "2B" },
                    { new Guid("2a74e1fd-5300-4429-b514-2a2ff38fe3ee"), "3B" },
                    { new Guid("c7971b9d-527b-4219-a62c-cb22b7ad5d8b"), "SS" },
                    { new Guid("5c4d8a08-6f75-4ff9-88a8-b9a1ab3a56c1"), "P" },
                    { new Guid("e45e52c9-0a2e-4290-bfeb-47cf15af922a"), "LF" },
                    { new Guid("958d2714-184f-4b56-ad55-05f9fd2da70b"), "RF" },
                    { new Guid("774493f8-f668-44fc-a348-73b8781ebb9c"), "CF" },
                    { new Guid("01644839-b2f5-4264-8387-0ff8c84a4b17"), "BD" }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersChangesGames");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("01644839-b2f5-4264-8387-0ff8c84a4b17"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0b2f472a-f4b5-45fe-8236-82c94e6ac945"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("2a74e1fd-5300-4429-b514-2a2ff38fe3ee"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("5c4d8a08-6f75-4ff9-88a8-b9a1ab3a56c1"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6128334e-197f-41c6-b92d-27dfde1ba609"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("774493f8-f668-44fc-a348-73b8781ebb9c"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("958d2714-184f-4b56-ad55-05f9fd2da70b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a3ebf1ed-141f-4e33-a745-71535b046afb"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("c7971b9d-527b-4219-a62c-cb22b7ad5d8b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("e45e52c9-0a2e-4290-bfeb-47cf15af922a"));

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PositionName" },
                values: new object[,]
                {
                    { new Guid("6cfa519e-dc6a-42c5-96a0-8b48aa58b84e"), "C" },
                    { new Guid("3b05a7c8-f0b5-4006-a447-ec080eeee51d"), "1B" },
                    { new Guid("27ff8b46-e00b-47a4-bd1e-989c7896fb9e"), "2B" },
                    { new Guid("1c1ed8c3-d023-4bca-9ae4-b5d3efda30d9"), "3B" },
                    { new Guid("bdbcc356-36e3-4b57-9a5f-405cec9c475a"), "SS" },
                    { new Guid("9d3c268e-d2c6-41a3-839d-bfc0e7ebb6b7"), "P" },
                    { new Guid("fddc8276-76ad-4dd2-89cc-dfe20a2dcdf7"), "LF" },
                    { new Guid("f6c693ca-9af3-4464-9549-61452dc5cb66"), "RF" },
                    { new Guid("597fe1a4-236f-4c8a-b1d2-3f6d0bb21be9"), "CF" },
                    { new Guid("7209556c-1887-465a-a7e4-5ec6d8eddf50"), "BD" }
                });
        }
    }
}
