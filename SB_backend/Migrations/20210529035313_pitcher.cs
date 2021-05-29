using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class pitcher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPlayerChangeGame_Teams_LoserTeamId",
                table: "PositionPlayerChangeGame");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPlayerChangeGame_Teams_WinerTeamId",
                table: "PositionPlayerChangeGame");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPlayerChangeGame_PositionPlayers_PlayerInPlayerId_PlayerInPositionId",
                table: "PositionPlayerChangeGame");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPlayerChangeGame_PositionPlayers_PlayerOutPlayerId_PlayerOutPositionId",
                table: "PositionPlayerChangeGame");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPlayerChangeGame_Series_SerieId_SerieInitDate_SerieEndDate",
                table: "PositionPlayerChangeGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionPlayerChangeGame",
                table: "PositionPlayerChangeGame");

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
                name: "PositionPlayerChangeGame",
                newName: "PositionPlayerChagesGames");

            migrationBuilder.RenameTable(
                name: "PlayerGame",
                newName: "PlayersGames");

            migrationBuilder.RenameIndex(
                name: "IX_PositionPlayerChangeGame_SerieId_SerieInitDate_SerieEndDate",
                table: "PositionPlayerChagesGames",
                newName: "IX_PositionPlayerChagesGames_SerieId_SerieInitDate_SerieEndDate");

            migrationBuilder.RenameIndex(
                name: "IX_PositionPlayerChangeGame_PlayerOutPlayerId_PlayerOutPositionId",
                table: "PositionPlayerChagesGames",
                newName: "IX_PositionPlayerChagesGames_PlayerOutPlayerId_PlayerOutPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_PositionPlayerChangeGame_PlayerInPlayerId_PlayerInPositionId",
                table: "PositionPlayerChagesGames",
                newName: "IX_PositionPlayerChagesGames_PlayerInPlayerId_PlayerInPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_PositionPlayerChangeGame_WinerTeamId",
                table: "PositionPlayerChagesGames",
                newName: "IX_PositionPlayerChagesGames_WinerTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_PositionPlayerChangeGame_LoserTeamId",
                table: "PositionPlayerChagesGames",
                newName: "IX_PositionPlayerChagesGames_LoserTeamId");

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
                name: "PK_PositionPlayerChagesGames",
                table: "PositionPlayerChagesGames",
                columns: new[] { "GameTime", "GameDate", "SerieId", "SerieInitDate", "SerieEndDate", "PlayerInPlayerId", "PlayerInPositionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayersGames",
                table: "PlayersGames",
                columns: new[] { "GameTime", "GameDate", "SerieId", "SerieInitDate", "SerieEndDate", "PositionPlayerPlayerId", "PositionPlayerPositionId" });

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

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PositionName" },
                values: new object[,]
                {
                    { new Guid("37fe09f2-0880-48d1-873c-cd42b4897997"), "C" },
                    { new Guid("6a299da8-243e-4272-b003-229e96d0a9f4"), "1B" },
                    { new Guid("a02e93d4-fe9a-4c53-a4ae-9cbc43ec3744"), "2B" },
                    { new Guid("0cdc03f7-c99f-498f-a683-daa9d71f348e"), "3B" },
                    { new Guid("9fe1a730-b66c-4b14-8703-a1baa12019de"), "SS" },
                    { new Guid("cce30ae7-5973-4837-8425-659dbe049aba"), "P" },
                    { new Guid("eadfd007-4fde-4f77-a5f7-93c13a1e4bb2"), "LF" },
                    { new Guid("6ae6a5fb-ebd5-49d7-a8a0-b6332f5a8593"), "RF" },
                    { new Guid("4339707a-0829-4eb1-b3aa-3a6a413bf127"), "CF" },
                    { new Guid("54afb3e1-b4fb-406c-8c96-2e115f02e366"), "BD" }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPlayerChagesGames_Teams_LoserTeamId",
                table: "PositionPlayerChagesGames",
                column: "LoserTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPlayerChagesGames_Teams_WinerTeamId",
                table: "PositionPlayerChagesGames",
                column: "WinerTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPlayerChagesGames_PositionPlayers_PlayerInPlayerId_PlayerInPositionId",
                table: "PositionPlayerChagesGames",
                columns: new[] { "PlayerInPlayerId", "PlayerInPositionId" },
                principalTable: "PositionPlayers",
                principalColumns: new[] { "PlayerId", "PositionId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPlayerChagesGames_PositionPlayers_PlayerOutPlayerId_PlayerOutPositionId",
                table: "PositionPlayerChagesGames",
                columns: new[] { "PlayerOutPlayerId", "PlayerOutPositionId" },
                principalTable: "PositionPlayers",
                principalColumns: new[] { "PlayerId", "PositionId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPlayerChagesGames_Series_SerieId_SerieInitDate_SerieEndDate",
                table: "PositionPlayerChagesGames",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" },
                principalTable: "Series",
                principalColumns: new[] { "Id", "InitDate", "EndDate" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPlayerChagesGames_Teams_LoserTeamId",
                table: "PositionPlayerChagesGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPlayerChagesGames_Teams_WinerTeamId",
                table: "PositionPlayerChagesGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPlayerChagesGames_PositionPlayers_PlayerInPlayerId_PlayerInPositionId",
                table: "PositionPlayerChagesGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPlayerChagesGames_PositionPlayers_PlayerOutPlayerId_PlayerOutPositionId",
                table: "PositionPlayerChagesGames");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionPlayerChagesGames_Series_SerieId_SerieInitDate_SerieEndDate",
                table: "PositionPlayerChagesGames");

            migrationBuilder.DropTable(
                name: "PitcherChangesGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PositionPlayerChagesGames",
                table: "PositionPlayerChagesGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayersGames",
                table: "PlayersGames");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0cdc03f7-c99f-498f-a683-daa9d71f348e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("37fe09f2-0880-48d1-873c-cd42b4897997"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("4339707a-0829-4eb1-b3aa-3a6a413bf127"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("54afb3e1-b4fb-406c-8c96-2e115f02e366"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6a299da8-243e-4272-b003-229e96d0a9f4"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6ae6a5fb-ebd5-49d7-a8a0-b6332f5a8593"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("9fe1a730-b66c-4b14-8703-a1baa12019de"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a02e93d4-fe9a-4c53-a4ae-9cbc43ec3744"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("cce30ae7-5973-4837-8425-659dbe049aba"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("eadfd007-4fde-4f77-a5f7-93c13a1e4bb2"));

            migrationBuilder.RenameTable(
                name: "PositionPlayerChagesGames",
                newName: "PositionPlayerChangeGame");

            migrationBuilder.RenameTable(
                name: "PlayersGames",
                newName: "PlayerGame");

            migrationBuilder.RenameIndex(
                name: "IX_PositionPlayerChagesGames_SerieId_SerieInitDate_SerieEndDate",
                table: "PositionPlayerChangeGame",
                newName: "IX_PositionPlayerChangeGame_SerieId_SerieInitDate_SerieEndDate");

            migrationBuilder.RenameIndex(
                name: "IX_PositionPlayerChagesGames_PlayerOutPlayerId_PlayerOutPositionId",
                table: "PositionPlayerChangeGame",
                newName: "IX_PositionPlayerChangeGame_PlayerOutPlayerId_PlayerOutPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_PositionPlayerChagesGames_PlayerInPlayerId_PlayerInPositionId",
                table: "PositionPlayerChangeGame",
                newName: "IX_PositionPlayerChangeGame_PlayerInPlayerId_PlayerInPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_PositionPlayerChagesGames_WinerTeamId",
                table: "PositionPlayerChangeGame",
                newName: "IX_PositionPlayerChangeGame_WinerTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_PositionPlayerChagesGames_LoserTeamId",
                table: "PositionPlayerChangeGame",
                newName: "IX_PositionPlayerChangeGame_LoserTeamId");

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
                name: "PK_PositionPlayerChangeGame",
                table: "PositionPlayerChangeGame",
                columns: new[] { "GameTime", "GameDate", "SerieId", "SerieInitDate", "SerieEndDate", "PlayerInPlayerId", "PlayerInPositionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerGame",
                table: "PlayerGame",
                columns: new[] { "GameTime", "GameDate", "SerieId", "SerieInitDate", "SerieEndDate", "PositionPlayerPlayerId", "PositionPlayerPositionId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPlayerChangeGame_Teams_LoserTeamId",
                table: "PositionPlayerChangeGame",
                column: "LoserTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPlayerChangeGame_Teams_WinerTeamId",
                table: "PositionPlayerChangeGame",
                column: "WinerTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPlayerChangeGame_PositionPlayers_PlayerInPlayerId_PlayerInPositionId",
                table: "PositionPlayerChangeGame",
                columns: new[] { "PlayerInPlayerId", "PlayerInPositionId" },
                principalTable: "PositionPlayers",
                principalColumns: new[] { "PlayerId", "PositionId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPlayerChangeGame_PositionPlayers_PlayerOutPlayerId_PlayerOutPositionId",
                table: "PositionPlayerChangeGame",
                columns: new[] { "PlayerOutPlayerId", "PlayerOutPositionId" },
                principalTable: "PositionPlayers",
                principalColumns: new[] { "PlayerId", "PositionId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionPlayerChangeGame_Series_SerieId_SerieInitDate_SerieEndDate",
                table: "PositionPlayerChangeGame",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" },
                principalTable: "Series",
                principalColumns: new[] { "Id", "InitDate", "EndDate" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
