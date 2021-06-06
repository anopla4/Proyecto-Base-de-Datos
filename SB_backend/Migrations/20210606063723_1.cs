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
                table: "Caracters",
                columns: new[] { "Id", "Caracter_Name" },
                values: new object[] { new Guid("274f1ee4-3564-4b9c-8f9c-75bbfc20d4fc"), "Nacional" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "ImgPath", "Name" },
                values: new object[,]
                {
                    { new Guid("d7ea6570-a782-4236-bf39-4f852e2ffc34"), null, "Jose Antonio Garcia Uña" },
                    { new Guid("a47471c0-2c48-4956-a6f0-0193752eb0be"), null, "Jose Luis Rodriguez Pantoja" },
                    { new Guid("cd118d72-8543-42aa-ad6c-5df2a39a9e62"), null, "Fransisco Martinez Sanchez" },
                    { new Guid("5abc5ecc-e439-434c-af9b-c791d051fb8c"), null, "Eriberto Rosales Hernandez" },
                    { new Guid("bc35b109-4b68-46c4-b83a-ac26d2734b7c"), null, "Agustin Lescaille Lopez" },
                    { new Guid("c732f890-05c8-42f8-9cad-1e46d52ff6ec"), null, "Alexander Urquiola Hernandez" },
                    { new Guid("66e76481-6af7-440b-9321-4c274d21f54c"), null, "Carlos Manuel Marti Santos" },
                    { new Guid("c68c20a4-80e6-4a26-8420-32d0f023ffa1"), null, "Eriel Sanchez Leon" },
                    { new Guid("84e072e7-11b9-48db-9d14-5d18df733e24"), null, "Miguel Borroto Gonzales" },
                    { new Guid("31c778f7-e1c6-44c4-ba5c-bb6f37acb64b"), null, "Michael Gonazalez Ventura" },
                    { new Guid("c4ad1b19-e3c4-4bf0-a3a2-2cd75800a4b6"), null, "Alain Alvarez Moya" },
                    { new Guid("534abec3-505b-4525-b94c-68e3bdb0390a"), null, "Pablo Alberto Civil Espinosa" },
                    { new Guid("e6d4c869-7fa4-4eb2-8d4d-f5eb6567e5a7"), null, "Yorelvis Charles Martinez" },
                    { new Guid("1a2fa462-a320-43dd-9903-41177f50f8dd"), null, "Guillermo Rolando Carmona Casanova" },
                    { new Guid("9aeff7f0-6843-4637-b8d8-fced1a49d32b"), null, "Manuel Vigoa Amore" },
                    { new Guid("6e6343ad-530a-4140-9607-72782aae74c4"), null, "Armando Jesus Ferrer Ruiz" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "Average", "Current_TeamId", "DeffAverage", "ERA", "Hand", "ImgPath", "Name", "Year_Experience" },
                values: new object[,]
                {
                    { new Guid("80d98e21-f989-4db7-b4f0-9f84088a9424"), 31, null, null, 0, null, null, null, "Yasniel Gonzalez Vega", 11 },
                    { new Guid("b0b73904-816d-4ec8-957a-e1c479dd0a44"), 24, null, null, 0, null, null, null, "Geyser Cepeda Lima", 4 },
                    { new Guid("49ca16f2-ab20-478e-a09d-47371337c577"), 41, null, null, 0, null, null, null, "Frederich Cepeda Cruz", 24 },
                    { new Guid("488af061-69e1-42bf-91ee-603271758d8c"), 23, null, null, 0, null, null, null, "Yosimar Cousin De La Rosa", 6 },
                    { new Guid("50ceec15-5eed-4dee-8903-ad7b8b9436a4"), 33, null, null, 0, null, null, null, "Rodolfo Soris Yera", 12 },
                    { new Guid("e53c8e44-4792-4b8c-aa57-b04e961abefb"), 24, null, null, 0, null, null, null, "Carlos Enrique Vera Barreda", 3 },
                    { new Guid("96638775-f065-4dfb-91e9-5e5f66437c11"), 24, null, null, 0, null, null, null, "Yoidel Castaneda Donny", 3 },
                    { new Guid("84930b33-5018-4357-94ce-a3a6de2ea301"), 36, null, null, 0, null, null, null, "Luis Angel Gomez Gamez", 15 },
                    { new Guid("714420d1-2804-47f8-aaf1-79a522623274"), 35, null, null, 0, null, null, null, "Noelvis Entenza Gonzalez", 4 },
                    { new Guid("3b925682-371c-4d5b-ae8a-c5aef7ee0d17"), 30, null, null, 0, null, null, null, "Yaniel Blanco Portal", 9 },
                    { new Guid("e5bbc503-cf80-4348-a63a-b47a38c0adee"), 22, null, null, 0, null, null, null, "Cesar Prieto Echevarria", 4 },
                    { new Guid("4536f820-d112-448e-8a52-cb4134e2f824"), 26, null, null, 0, null, null, null, "Ruben Rodriguez Fonseca", 4 },
                    { new Guid("6c84051a-5390-4e68-b3d1-adcae4d053c6"), 29, null, null, 0, null, null, null, "Rafael Viñales Alvarez", 10 },
                    { new Guid("c71dbf8a-a499-4753-8177-8bb613fa77f2"), 37, null, null, 0, null, null, null, "Dennis Laza Spencer", 12 },
                    { new Guid("0ca7d240-608c-46c0-ae3b-560441996ce0"), 22, null, null, 0, null, null, null, "Miguel Antonio Gonzalez Puentes", 1 },
                    { new Guid("492ce38b-3d50-4ad1-b62f-04bbbe8b9f19"), 29, null, null, 0, null, null, null, "Frank Madan Montejo", 12 },
                    { new Guid("7c1eed91-70ea-4e1d-8d04-8ce6bb1f832b"), 19, null, null, 0, null, null, null, "Luis Fonseca Garcia", 2 },
                    { new Guid("dc37be22-bb87-4dee-9d22-e1dd80639ebc"), 37, null, null, 0, null, null, null, "Yudier Rodriguez Leon", 13 },
                    { new Guid("205e50cc-6792-4d42-a09f-1a6f7925723f"), 34, null, null, 0, null, null, null, "Yoen Socarras Suarez", 15 },
                    { new Guid("60e597ae-52d5-4bcb-ad70-5108c9f4152c"), 35, null, null, 0, null, null, null, "Alberto Bicet Labrada", 15 },
                    { new Guid("009797dc-f53f-45c3-bba9-bb16951f0691"), 24, null, null, 0, null, null, null, "Yankiel Mauri Gutierrez", 6 },
                    { new Guid("f1e68897-9783-48d7-b9df-b1638ec2c480"), 21, null, null, 0, null, null, null, "Leonardo Montero Alfonso", 1 },
                    { new Guid("b222b771-1c84-46e0-9651-1c0edb1ed8e0"), 27, null, null, 0, null, null, null, "Yoan Moreno Rodriguez", 7 },
                    { new Guid("fa073b24-5a15-4f46-ae88-ff75df54fbea"), 31, null, null, 0, null, null, null, "Osvaldo Vazquez Torres", 12 },
                    { new Guid("f7c39bc3-ca0b-4a2a-a851-210f3061810b"), 39, null, null, 0, null, null, null, "Yordanis Samon Matamoros", 18 },
                    { new Guid("d7b43556-3ab5-4912-b197-6bcaf52f445c"), 26, null, null, 0, null, null, null, "Adriel Echavarria Sanchez", 7 },
                    { new Guid("d8e175e8-caf8-4a0f-995d-bd28ab2287d1"), 36, null, null, 0, null, null, null, "Yosvani Alarcon Tardio", 16 }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PositionName" },
                values: new object[,]
                {
                    { new Guid("0156a2e6-b9fe-43d8-9f68-012251df9e92"), "LF" },
                    { new Guid("13505c5f-d380-4cd0-9d58-fca642491f81"), "BD" },
                    { new Guid("c548fdc4-de7f-43c4-97fb-131e8234958b"), "CF" },
                    { new Guid("04a2cadc-4608-4a96-8f55-b4ceb793f51b"), "RF" },
                    { new Guid("bdcd2534-1ba3-4bd0-9099-13c6a0a9de41"), "P" },
                    { new Guid("f46b6571-8827-4736-b19f-d642fb7bf908"), "3B" },
                    { new Guid("ca2cc279-8a1d-49d2-bdc0-61c2c553e216"), "2B" },
                    { new Guid("a8660d61-d848-4a78-a41a-ea9c35d3f033"), "1B" },
                    { new Guid("57cbcda7-cbac-42b5-bc0e-c71eb8540e27"), "C" },
                    { new Guid("8e66be38-216d-4874-a8d1-26465e853000"), "SS" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Color", "ImgPath", "Initials", "Name" },
                values: new object[,]
                {
                    { new Guid("6c489cf8-0c95-4d6d-8046-37f3f3e47621"), "azul,blanco", null, "HLG", "Holguín" },
                    { new Guid("58cad299-e5e7-419b-93d7-154d084b2543"), "azul,rojo", null, "GRM", "Granma" },
                    { new Guid("1c6f9b78-d8d2-4ba8-909f-6db4629f1f08"), "azul,rojo", null, "CMG", "Camagüey" },
                    { new Guid("0c9f56f4-2634-42ae-a762-dad72ffff441"), "azul,rojo", null, "CAV", "Ciego de Ávila" },
                    { new Guid("ce405e0a-91a7-417f-9da4-74b0b75acc3c"), "azul,naranja", null, "SSP", "SanctiSpiritus" },
                    { new Guid("75e36e7e-6b97-4044-bfc4-437e193d074f"), "naranja", null, "VCL", "Villa Clara" },
                    { new Guid("5d503b90-135b-4fe9-bb6f-70fd85d422e1"), "rojo,amarillo", null, "MTZ", "Matanzas" },
                    { new Guid("a6da048a-7794-44de-8c55-0b0fc599d1cb"), "verde,gris", null, "CFG", "Cienfuegos" },
                    { new Guid("b6e6b08c-9b2b-45eb-978b-c22d1f06142f"), "azul", null, "IND", "Industriales" },
                    { new Guid("6a472570-f244-4828-acc4-53bf7f862712"), "rojo", null, "MAY", "Mayabeque" },
                    { new Guid("185adf42-a57e-4ec8-8e22-25f62aa85a17"), "verde", null, "PRI", "Pinar del Río" },
                    { new Guid("8b0cdf30-6ea5-4f95-a736-273052cdf3a1"), "rojo", null, "ART", "Artemisa" },
                    { new Guid("88dc4e79-8f31-410c-b724-982a3abb68f1"), "rojo", null, "SCU", "Santiago de Cuba" },
                    { new Guid("0b8257f3-4916-42a1-93bc-d3cab4013318"), "azul,blanco", null, "IJV", "Isla dela Juventud" },
                    { new Guid("86894ece-e6ad-4135-b45b-000ca20bc242"), "rojo", null, "GTM", "Guantanamo" }
                });

            migrationBuilder.InsertData(
                table: "PlayerPosition",
                columns: new[] { "PlayerId", "PositionId" },
                values: new object[,]
                {
                    { new Guid("488af061-69e1-42bf-91ee-603271758d8c"), new Guid("bdcd2534-1ba3-4bd0-9099-13c6a0a9de41") },
                    { new Guid("714420d1-2804-47f8-aaf1-79a522623274"), new Guid("bdcd2534-1ba3-4bd0-9099-13c6a0a9de41") }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "InitDate", "EndDate", "CaracterId", "LoserId", "Name", "NumberOfGames", "NumberOfTeams", "WinerId" },
                values: new object[,]
                {
                    { new Guid("6e6343fd-530b-4140-9607-727828a774c4"), new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("274f1ee4-3564-4b9c-8f9c-75bbfc20d4fc"), new Guid("86894ece-e6ad-4135-b45b-000ca20bc242"), "60 Serie Nacional", 90, 16, new Guid("58cad299-e5e7-419b-93d7-154d084b2543") },
                    { new Guid("6a6345fd-431b-2120-9527-72782abf84c4"), new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("274f1ee4-3564-4b9c-8f9c-75bbfc20d4fc"), new Guid("86894ece-e6ad-4135-b45b-000ca20bc242"), "59 Serie Nacional", 90, 16, new Guid("5d503b90-135b-4fe9-bb6f-70fd85d422e1") }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "AgainstCarrers", "GameDate", "GameTime", "InFavorCarrers", "LoserTeamId", "PitcherLoserId", "PitcherWinerId", "SerieEndDate", "SerieId", "SerieInitDate", "WinerTeamId" },
                values: new object[] { new Guid("9c9cdf30-6ea5-4f95-a736-273052cdf3a4"), 8, new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "14:00", 15, new Guid("1c6f9b78-d8d2-4ba8-909f-6db4629f1f08"), new Guid("714420d1-2804-47f8-aaf1-79a522623274"), new Guid("488af061-69e1-42bf-91ee-603271758d8c"), new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6e6343fd-530b-4140-9607-727828a774c4"), new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5d503b90-135b-4fe9-bb6f-70fd85d422e1") });

            migrationBuilder.InsertData(
                table: "TeamsSeries",
                columns: new[] { "TeamId", "SerieId", "SerieInitDate", "SerieEndDate", "FinalPosition", "LostGames", "WonGames" },
                values: new object[,]
                {
                    { new Guid("5d503b90-135b-4fe9-bb6f-70fd85d422e1"), new Guid("6e6343fd-530b-4140-9607-727828a774c4"), new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 31, 44 },
                    { new Guid("1c6f9b78-d8d2-4ba8-909f-6db4629f1f08"), new Guid("6e6343fd-530b-4140-9607-727828a774c4"), new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 34, 41 }
                });

            migrationBuilder.InsertData(
                table: "TeamsSeriesPlayers",
                columns: new[] { "PlayerId", "SerieId", "SerieInitDate", "SerieEndDate", "TeamId" },
                values: new object[,]
                {
                    { new Guid("488af061-69e1-42bf-91ee-603271758d8c"), new Guid("6e6343fd-530b-4140-9607-727828a774c4"), new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5d503b90-135b-4fe9-bb6f-70fd85d422e1") },
                    { new Guid("714420d1-2804-47f8-aaf1-79a522623274"), new Guid("6e6343fd-530b-4140-9607-727828a774c4"), new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1c6f9b78-d8d2-4ba8-909f-6db4629f1f08") }
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
