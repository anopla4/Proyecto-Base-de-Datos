using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "img",
                table: "Teams",
                newName: "ImgPath");

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PlayerId", "PositionName" },
                values: new object[,]
                {
                    { new Guid("0accb8c4-64e8-48ae-a7f3-4c49f625fdf6"), null, "C" },
                    { new Guid("83401196-0a01-4b72-886d-85d1dac7c5e9"), null, "1B" },
                    { new Guid("4406f789-1ff6-4c9e-b4f6-9ec4f5267e72"), null, "2B" },
                    { new Guid("e0a34184-4eb0-4125-80f9-18c8f22f21ee"), null, "3B" },
                    { new Guid("309c87fd-04fe-4d7f-ab17-29828fa182ac"), null, "SS" },
                    { new Guid("254aeb15-4e51-45b7-9498-e1f30fc0c01e"), null, "P" },
                    { new Guid("a9964fe4-3503-401d-8237-eef56290e603"), null, "LF" },
                    { new Guid("984f0412-598f-42e5-90c3-ec9cee781c91"), null, "RF" },
                    { new Guid("5c383ffb-14cd-432c-8fa8-f82bfe056733"), null, "CF" },
                    { new Guid("6177244a-6c4e-4763-b941-4a915ee87c3c"), null, "BD" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0accb8c4-64e8-48ae-a7f3-4c49f625fdf6"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("254aeb15-4e51-45b7-9498-e1f30fc0c01e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("309c87fd-04fe-4d7f-ab17-29828fa182ac"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("4406f789-1ff6-4c9e-b4f6-9ec4f5267e72"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("5c383ffb-14cd-432c-8fa8-f82bfe056733"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6177244a-6c4e-4763-b941-4a915ee87c3c"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("83401196-0a01-4b72-886d-85d1dac7c5e9"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("984f0412-598f-42e5-90c3-ec9cee781c91"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a9964fe4-3503-401d-8237-eef56290e603"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("e0a34184-4eb0-4125-80f9-18c8f22f21ee"));

            migrationBuilder.RenameColumn(
                name: "ImgPath",
                table: "Teams",
                newName: "img");

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
    }
}
