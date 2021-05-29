using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class testing2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersGames_Teams_LoserTeamId",
                table: "PlayersGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersGames_Teams_WinerTeamId",
                table: "PlayersGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersGames_PositionPlayers_PositionPlayerPlayerId_PositionPlayerPositionId",
                table: "PlayersGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersGames_Series_SerieId_SerieInitDate_SerieEndDate",
                table: "PlayersGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayersGames",
                table: "PlayersGames");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("1c323e07-77d8-4043-bfbe-bbb92437dd03"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("3a7e4c3b-a2a6-44ba-ac92-eef8cfc8d392"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("5212e411-7cd7-494f-9c18-1af659dbcc78"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("5d8ec263-bab7-43ba-b75c-78d050236347"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("69627233-8b2a-42a2-b7d2-50591f4da2aa"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("99c3259d-e432-484e-b5df-4f6663b5ec3f"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b28992f5-b3ce-4d08-9507-4daa84f2335c"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("be46fca2-9d4a-4e77-865e-e4e3c732714f"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("d89c2e9c-3b71-4633-ad9f-ee7f7514a4d8"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("def6c1b2-0bc0-4481-8578-70736cbe45b9"));

            migrationBuilder.RenameTable(
                name: "PlayersGames",
                newName: "PlayerGame");

            migrationBuilder.RenameIndex(
                name: "IX_PlayersGames_SerieId_SerieInitDate_SerieEndDate",
                table: "PlayerGame",
                newName: "IX_PlayerGame_SerieId_SerieInitDate_SerieEndDate");

            migrationBuilder.RenameIndex(
                name: "IX_PlayersGames_PositionPlayerPlayerId_PositionPlayerPositionId",
                table: "PlayerGame",
                newName: "IX_PlayerGame_PositionPlayerPlayerId_PositionPlayerPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayersGames_WinerTeamId",
                table: "PlayerGame",
                newName: "IX_PlayerGame_WinerTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayersGames_LoserTeamId",
                table: "PlayerGame",
                newName: "IX_PlayerGame_LoserTeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerGame",
                table: "PlayerGame",
                columns: new[] { "GameTime", "GameDate", "SerieId", "SerieInitDate", "SerieEndDate", "PositionPlayerPlayerId", "PositionPlayerPositionId" });

            migrationBuilder.CreateTable(
                name: "PositionPlayerChangeGame",
                columns: table => new
                {
                    WinerTeamId = table.Column<Guid>(nullable: false),
                    LoserTeamId = table.Column<Guid>(nullable: false),
                    GameDate = table.Column<DateTime>(type: "date", nullable: false),
                    GameTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SerieId = table.Column<Guid>(nullable: false),
                    SerieInitDate = table.Column<DateTime>(nullable: false),
                    SerieEndDate = table.Column<DateTime>(nullable: false),
                    PlayerInPlayerId = table.Column<Guid>(nullable: false),
                    PlayerInPositionId = table.Column<Guid>(nullable: false),
                    PlayerOutPlayerId = table.Column<Guid>(nullable: false),
                    PlayerOutPositionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionPlayerChangeGame", x => new { x.GameTime, x.GameDate, x.SerieId, x.SerieInitDate, x.SerieEndDate, x.PlayerInPlayerId, x.PlayerInPositionId });
                    table.ForeignKey(
                        name: "FK_PositionPlayerChangeGame_Teams_LoserTeamId",
                        column: x => x.LoserTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PositionPlayerChangeGame_Teams_WinerTeamId",
                        column: x => x.WinerTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PositionPlayerChangeGame_PositionPlayers_PlayerInPlayerId_PlayerInPositionId",
                        columns: x => new { x.PlayerInPlayerId, x.PlayerInPositionId },
                        principalTable: "PositionPlayers",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PositionPlayerChangeGame_PositionPlayers_PlayerOutPlayerId_PlayerOutPositionId",
                        columns: x => new { x.PlayerOutPlayerId, x.PlayerOutPositionId },
                        principalTable: "PositionPlayers",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PositionPlayerChangeGame_Series_SerieId_SerieInitDate_SerieEndDate",
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
                    { new Guid("3b8ec332-aa21-403e-81ad-35af967e9523"), "C" },
                    { new Guid("fe5fa58f-7e72-4b6e-af4d-c5658df96ac9"), "1B" },
                    { new Guid("bb2318e8-299e-4ed1-bba1-8e6670ffc043"), "2B" },
                    { new Guid("b6110781-ca5e-4b58-a6da-d12fe019fcaa"), "3B" },
                    { new Guid("34756ca9-ae74-46a2-81fb-a6d8df952825"), "SS" },
                    { new Guid("f90ef5d9-0913-4495-93f1-5a2ba541ca77"), "P" },
                    { new Guid("ed882a9f-4ce4-4144-a63c-b3bdd329c6e8"), "LF" },
                    { new Guid("e19b5d6d-da7b-416f-ae5f-67c18d64ac69"), "RF" },
                    { new Guid("e870403a-6bdd-45c5-af7b-a5284150299f"), "CF" },
                    { new Guid("2b592bfd-aacb-4ac8-b34b-40049c5b525c"), "BD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PositionPlayerChangeGame_LoserTeamId",
                table: "PositionPlayerChangeGame",
                column: "LoserTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionPlayerChangeGame_WinerTeamId",
                table: "PositionPlayerChangeGame",
                column: "WinerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionPlayerChangeGame_PlayerInPlayerId_PlayerInPositionId",
                table: "PositionPlayerChangeGame",
                columns: new[] { "PlayerInPlayerId", "PlayerInPositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_PositionPlayerChangeGame_PlayerOutPlayerId_PlayerOutPositionId",
                table: "PositionPlayerChangeGame",
                columns: new[] { "PlayerOutPlayerId", "PlayerOutPositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_PositionPlayerChangeGame_SerieId_SerieInitDate_SerieEndDate",
                table: "PositionPlayerChangeGame",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGame_Teams_LoserTeamId",
                table: "PlayerGame",
                column: "LoserTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGame_Teams_WinerTeamId",
                table: "PlayerGame",
                column: "WinerTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGame_PositionPlayers_PositionPlayerPlayerId_PositionPlayerPositionId",
                table: "PlayerGame",
                columns: new[] { "PositionPlayerPlayerId", "PositionPlayerPositionId" },
                principalTable: "PositionPlayers",
                principalColumns: new[] { "PlayerId", "PositionId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGame_Series_SerieId_SerieInitDate_SerieEndDate",
                table: "PlayerGame",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" },
                principalTable: "Series",
                principalColumns: new[] { "Id", "InitDate", "EndDate" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGame_Teams_LoserTeamId",
                table: "PlayerGame");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGame_Teams_WinerTeamId",
                table: "PlayerGame");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGame_PositionPlayers_PositionPlayerPlayerId_PositionPlayerPositionId",
                table: "PlayerGame");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGame_Series_SerieId_SerieInitDate_SerieEndDate",
                table: "PlayerGame");

            migrationBuilder.DropTable(
                name: "PositionPlayerChangeGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerGame",
                table: "PlayerGame");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("2b592bfd-aacb-4ac8-b34b-40049c5b525c"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("34756ca9-ae74-46a2-81fb-a6d8df952825"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("3b8ec332-aa21-403e-81ad-35af967e9523"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b6110781-ca5e-4b58-a6da-d12fe019fcaa"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("bb2318e8-299e-4ed1-bba1-8e6670ffc043"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("e19b5d6d-da7b-416f-ae5f-67c18d64ac69"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("e870403a-6bdd-45c5-af7b-a5284150299f"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("ed882a9f-4ce4-4144-a63c-b3bdd329c6e8"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f90ef5d9-0913-4495-93f1-5a2ba541ca77"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("fe5fa58f-7e72-4b6e-af4d-c5658df96ac9"));

            migrationBuilder.RenameTable(
                name: "PlayerGame",
                newName: "PlayersGames");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGame_SerieId_SerieInitDate_SerieEndDate",
                table: "PlayersGames",
                newName: "IX_PlayersGames_SerieId_SerieInitDate_SerieEndDate");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGame_PositionPlayerPlayerId_PositionPlayerPositionId",
                table: "PlayersGames",
                newName: "IX_PlayersGames_PositionPlayerPlayerId_PositionPlayerPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGame_WinerTeamId",
                table: "PlayersGames",
                newName: "IX_PlayersGames_WinerTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGame_LoserTeamId",
                table: "PlayersGames",
                newName: "IX_PlayersGames_LoserTeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayersGames",
                table: "PlayersGames",
                columns: new[] { "GameTime", "GameDate", "SerieId", "SerieInitDate", "SerieEndDate", "PositionPlayerPlayerId", "PositionPlayerPositionId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersGames_Teams_LoserTeamId",
                table: "PlayersGames",
                column: "LoserTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersGames_Teams_WinerTeamId",
                table: "PlayersGames",
                column: "WinerTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersGames_PositionPlayers_PositionPlayerPlayerId_PositionPlayerPositionId",
                table: "PlayersGames",
                columns: new[] { "PositionPlayerPlayerId", "PositionPlayerPositionId" },
                principalTable: "PositionPlayers",
                principalColumns: new[] { "PlayerId", "PositionId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersGames_Series_SerieId_SerieInitDate_SerieEndDate",
                table: "PlayersGames",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" },
                principalTable: "Series",
                principalColumns: new[] { "Id", "InitDate", "EndDate" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
