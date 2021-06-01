using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    AgainstCarrers = table.Column<int>(nullable: false)
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
                    PlayerId = table.Column<Guid>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersGames", x => new { x.GameId, x.PlayerId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_PlayersGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersGames_PlayerPosition_PlayerId_PositionId",
                        columns: x => new { x.PlayerId, x.PositionId },
                        principalTable: "PlayerPosition",
                        principalColumns: new[] { "PlayerId", "PositionId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PositionName" },
                values: new object[,]
                {
                    { new Guid("06c6d50d-f572-4efe-9dbd-6eeef6c4a1bb"), "C" },
                    { new Guid("1b65b402-6c75-4666-bcf9-70a339d9ca72"), "1B" },
                    { new Guid("23502d9c-7139-4643-a853-b2579bcb41af"), "2B" },
                    { new Guid("fc4b39e8-120c-4aae-866d-570f0cbc6103"), "3B" },
                    { new Guid("81075d5f-295c-4741-84e0-2c23fdfdd668"), "SS" },
                    { new Guid("9f4e4dc1-6f69-49ad-85d9-02677a44eb13"), "P" },
                    { new Guid("48c3288d-703e-4646-ba6e-f84acf8cf2da"), "LF" },
                    { new Guid("2f647bd2-93a6-4df0-84fa-c43b205ce25e"), "RF" },
                    { new Guid("4adc7f90-81f4-404f-b2f4-c196a8a12e9e"), "CF" },
                    { new Guid("435606e1-afff-4d31-b615-102e495a1437"), "BD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_PlayersGames_PlayerId_PositionId",
                table: "PlayersGames",
                columns: new[] { "PlayerId", "PositionId" });

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
