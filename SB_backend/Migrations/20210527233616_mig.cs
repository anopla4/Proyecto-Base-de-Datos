using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0495a2ca-b6e5-456c-be5a-96223ccaf2cc"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("2303c988-2283-47c3-8509-5d42724bd2a2"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("2af415a2-f1b8-4f68-8e71-0a581cf8cb15"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("3c383560-3658-45ff-9089-7ef0eaafa5e8"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("57307906-6132-471e-93f8-d57d272b545e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6b06a626-6ae4-4710-a058-0bf90824b1a5"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("7854f0a9-04fa-4a5c-bb84-41db52ad4bcd"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("afef3de9-578d-4185-94d8-1b165caf79ec"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("c7ba4130-ed5a-4c31-8deb-2096344b5403"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f4a74e66-0307-4771-91e1-29c39bef8781"));

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

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Position_Name" },
                values: new object[,]
                {
                    { new Guid("49da1bc3-5fc7-4009-8253-314f14dc858c"), "C" },
                    { new Guid("6ffb6305-2971-4e30-983b-0580533aa379"), "1B" },
                    { new Guid("6bd2e055-6b9a-4a1f-93ec-dc42a9757cb6"), "2B" },
                    { new Guid("fba10b37-d111-4f3a-a73f-e1ca61a16911"), "3B" },
                    { new Guid("08c80676-3232-461b-97ba-a74587a565ea"), "SS" },
                    { new Guid("abbb40a2-e3f6-4958-8fce-503debaf0efb"), "Lanzador" },
                    { new Guid("a93c2b6a-c4e1-4f8d-af82-4829f5048328"), "LF" },
                    { new Guid("19a198ae-8ce0-4696-9569-e3474b245882"), "RF" },
                    { new Guid("ad33fb53-a275-44d3-ac76-63a771fa038b"), "CF" },
                    { new Guid("13ebe3d3-2695-4a50-98c4-36badbb8de36"), "BD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamsSeriesDirectors_TeamSerieId",
                table: "TeamsSeriesDirectors",
                column: "TeamSerieId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsSeriesDirectors_SerieId_SerieInitDate_SerieEndDate",
                table: "TeamsSeriesDirectors",
                columns: new[] { "SerieId", "SerieInitDate", "SerieEndDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamsSeriesDirectors");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("08c80676-3232-461b-97ba-a74587a565ea"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("13ebe3d3-2695-4a50-98c4-36badbb8de36"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("19a198ae-8ce0-4696-9569-e3474b245882"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("49da1bc3-5fc7-4009-8253-314f14dc858c"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6bd2e055-6b9a-4a1f-93ec-dc42a9757cb6"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6ffb6305-2971-4e30-983b-0580533aa379"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a93c2b6a-c4e1-4f8d-af82-4829f5048328"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("abbb40a2-e3f6-4958-8fce-503debaf0efb"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("ad33fb53-a275-44d3-ac76-63a771fa038b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("fba10b37-d111-4f3a-a73f-e1ca61a16911"));

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Position_Name" },
                values: new object[,]
                {
                    { new Guid("f4a74e66-0307-4771-91e1-29c39bef8781"), "C" },
                    { new Guid("2303c988-2283-47c3-8509-5d42724bd2a2"), "1B" },
                    { new Guid("57307906-6132-471e-93f8-d57d272b545e"), "2B" },
                    { new Guid("6b06a626-6ae4-4710-a058-0bf90824b1a5"), "3B" },
                    { new Guid("0495a2ca-b6e5-456c-be5a-96223ccaf2cc"), "SS" },
                    { new Guid("7854f0a9-04fa-4a5c-bb84-41db52ad4bcd"), "Lanzador" },
                    { new Guid("c7ba4130-ed5a-4c31-8deb-2096344b5403"), "LF" },
                    { new Guid("afef3de9-578d-4185-94d8-1b165caf79ec"), "RF" },
                    { new Guid("2af415a2-f1b8-4f68-8e71-0a581cf8cb15"), "CF" },
                    { new Guid("3c383560-3658-45ff-9089-7ef0eaafa5e8"), "BD" }
                });
        }
    }
}
