using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("2dc6eb15-df6d-4e08-b007-9c34a162c0c3"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("3370449e-4832-4f3b-b9b2-312e4ea1375b"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("758c0f5b-d4b6-48bf-bb2b-8a9f548229de"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("861f4663-71ea-4f58-b9b9-6031887e474c"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("887fe64c-692c-486c-887e-81e10d40d4e8"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("8ef14405-1dc9-4ad1-8ee6-2f0df6b6f9e0"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a693aea7-fc89-47a9-97ef-5f7c4c730426"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("cfa29702-3d36-480d-855c-a4b2e7fc05c6"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("f78a20b5-726a-4380-868d-839e4c222f50"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("fc028a3a-9606-4dc7-bc19-2bd9f07145fd"));

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PositionName" },
                values: new object[,]
                {
                    { new Guid("a0ce4dae-a07b-48a8-9128-a414f29cc751"), "C" },
                    { new Guid("ee011b87-3fca-4d18-b5c0-a76e65933e1c"), "1B" },
                    { new Guid("47a1ebd9-0ccc-4c93-9969-3d035b2a3f15"), "2B" },
                    { new Guid("920ba7ab-9b52-4ecf-b580-1dc449bd43f3"), "3B" },
                    { new Guid("7549f2ff-79bc-4773-a98d-4f5dec313a29"), "SS" },
                    { new Guid("e19aae30-d600-4239-9eaa-1c5a03c3d2a5"), "P" },
                    { new Guid("3aee5054-2da4-4494-a712-39a61e6a7120"), "LF" },
                    { new Guid("6b299223-1db8-43b7-9cce-8d7df1bbf7a6"), "RF" },
                    { new Guid("ef2d0ac1-bd6c-4aaa-bb28-e7b49d8c043a"), "CF" },
                    { new Guid("93b59a65-ab15-4136-86a0-b5c5341c390e"), "BD" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("3aee5054-2da4-4494-a712-39a61e6a7120"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("47a1ebd9-0ccc-4c93-9969-3d035b2a3f15"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("6b299223-1db8-43b7-9cce-8d7df1bbf7a6"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("7549f2ff-79bc-4773-a98d-4f5dec313a29"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("920ba7ab-9b52-4ecf-b580-1dc449bd43f3"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("93b59a65-ab15-4136-86a0-b5c5341c390e"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a0ce4dae-a07b-48a8-9128-a414f29cc751"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("e19aae30-d600-4239-9eaa-1c5a03c3d2a5"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("ee011b87-3fca-4d18-b5c0-a76e65933e1c"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("ef2d0ac1-bd6c-4aaa-bb28-e7b49d8c043a"));

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "PositionName" },
                values: new object[,]
                {
                    { new Guid("758c0f5b-d4b6-48bf-bb2b-8a9f548229de"), "C" },
                    { new Guid("861f4663-71ea-4f58-b9b9-6031887e474c"), "1B" },
                    { new Guid("a693aea7-fc89-47a9-97ef-5f7c4c730426"), "2B" },
                    { new Guid("2dc6eb15-df6d-4e08-b007-9c34a162c0c3"), "3B" },
                    { new Guid("8ef14405-1dc9-4ad1-8ee6-2f0df6b6f9e0"), "SS" },
                    { new Guid("f78a20b5-726a-4380-868d-839e4c222f50"), "P" },
                    { new Guid("887fe64c-692c-486c-887e-81e10d40d4e8"), "LF" },
                    { new Guid("3370449e-4832-4f3b-b9b2-312e4ea1375b"), "RF" },
                    { new Guid("cfa29702-3d36-480d-855c-a4b2e7fc05c6"), "CF" },
                    { new Guid("fc028a3a-9606-4dc7-bc19-2bd9f07145fd"), "BD" }
                });
        }
    }
}
