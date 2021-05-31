using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Directors",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PlayerId", "PositionName" },
                values: new object[,]
                {
                    { new Guid("05485544-d207-4b0f-8b02-0bab06c3c073"), null, "C" },
                    { new Guid("63b7994c-77f5-43b4-91d3-93f84f4901f3"), null, "1B" },
                    { new Guid("63d2dd45-c59d-40b5-8cd2-fb00d48b6234"), null, "2B" },
                    { new Guid("f814ae3f-bbaa-4852-800a-e101686ff499"), null, "3B" },
                    { new Guid("f89320f2-87a8-4017-9bbd-2e7e14d5368d"), null, "SS" },
                    { new Guid("0ac31ac4-fdea-48a3-a265-d8bdd5b01d67"), null, "P" },
                    { new Guid("6e610c27-1fef-4f40-972e-85db0be05d58"), null, "LF" },
                    { new Guid("3f72a3f0-a790-4f90-a325-27d88e6093b8"), null, "RF" },
                    { new Guid("db2c5b30-69c2-49c6-8a1d-5ee9dd258807"), null, "CF" },
                    { new Guid("10bc1a46-32bd-4814-97e1-0ced00101136"), null, "BD" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("05485544-d207-4b0f-8b02-0bab06c3c073"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0ac31ac4-fdea-48a3-a265-d8bdd5b01d67"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("10bc1a46-32bd-4814-97e1-0ced00101136"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("3f72a3f0-a790-4f90-a325-27d88e6093b8"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("63b7994c-77f5-43b4-91d3-93f84f4901f3"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("63d2dd45-c59d-40b5-8cd2-fb00d48b6234"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6e610c27-1fef-4f40-972e-85db0be05d58"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("db2c5b30-69c2-49c6-8a1d-5ee9dd258807"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f814ae3f-bbaa-4852-800a-e101686ff499"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f89320f2-87a8-4017-9bbd-2e7e14d5368d"));

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Directors");

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
    }
}
