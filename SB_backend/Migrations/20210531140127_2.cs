using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0683f316-c01b-475f-8888-856a33725bdd"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("10b1cfac-3095-4813-abe4-55cf851878b7"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("10d23c46-b623-48d0-a43e-832d89d9243e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("11440ccb-00ee-40e7-99c2-af8ae43f7cc6"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("275e26ca-7373-4281-a900-a25d513cd8c5"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("3bdcf06c-4b5b-4fe0-a0d3-5d66ff6d5344"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("70055929-a66e-4af5-9db9-4af03efb60a9"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("936554d8-1e0c-40a3-9953-5e51f4e13d0c"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a18e810f-3533-4523-9ee3-ed60b8dc0617"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("ece5db98-3593-4a88-8b69-89009f87a7d3"));

            migrationBuilder.RenameColumn(
                name: "img",
                table: "Players",
                newName: "ImgPath");

            migrationBuilder.AddColumn<int>(
                name: "Hand",
                table: "Players",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PlayerId", "PositionName" },
                values: new object[,]
                {
                    { new Guid("6a78cfdf-2ca2-40a9-9e79-daaa6003d7cc"), null, "C" },
                    { new Guid("a90ebaaf-2e81-4b3a-87cd-fba3975e3d97"), null, "1B" },
                    { new Guid("afda331e-ccfa-4e1e-af39-7482ee888da6"), null, "2B" },
                    { new Guid("049e7a51-7bef-43a0-8be4-0a0f6bb27bc4"), null, "3B" },
                    { new Guid("780cabd8-77b1-404a-b506-e31814d28354"), null, "SS" },
                    { new Guid("9f1b1b92-f947-4a19-a2d8-b18531ac596c"), null, "P" },
                    { new Guid("e1230aed-fb46-4c93-bb87-de2bd6178a5b"), null, "LF" },
                    { new Guid("0e7afdf7-2ccb-4313-9466-ba0edd061edd"), null, "RF" },
                    { new Guid("6700c7c7-f06b-40ef-964a-53003d95d606"), null, "CF" },
                    { new Guid("f92a2385-6d3f-4c81-b766-c5d703896c25"), null, "BD" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("049e7a51-7bef-43a0-8be4-0a0f6bb27bc4"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0e7afdf7-2ccb-4313-9466-ba0edd061edd"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6700c7c7-f06b-40ef-964a-53003d95d606"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6a78cfdf-2ca2-40a9-9e79-daaa6003d7cc"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("780cabd8-77b1-404a-b506-e31814d28354"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("9f1b1b92-f947-4a19-a2d8-b18531ac596c"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a90ebaaf-2e81-4b3a-87cd-fba3975e3d97"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("afda331e-ccfa-4e1e-af39-7482ee888da6"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("e1230aed-fb46-4c93-bb87-de2bd6178a5b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f92a2385-6d3f-4c81-b766-c5d703896c25"));

            migrationBuilder.DropColumn(
                name: "Hand",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "ImgPath",
                table: "Players",
                newName: "img");

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
        }
    }
}
