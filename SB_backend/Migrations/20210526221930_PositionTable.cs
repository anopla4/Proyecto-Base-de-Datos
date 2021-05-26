using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SB_backend.Migrations
{
    public partial class PositionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Position_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => new { x.Id, x.Position_Name });
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Position_Name" },
                values: new object[,]
                {
                    { new Guid("648d796e-78da-4249-a4be-f66ae0abb79c"), "C" },
                    { new Guid("2c709e68-1add-42ec-839b-681fec1eb9b6"), "1B" },
                    { new Guid("00000000-0000-0000-0000-000000000000"), "2B" },
                    { new Guid("e761a488-e708-4f04-a35e-0726877cd83e"), "3B" },
                    { new Guid("877da458-a2b7-4fed-969a-7a94578b2947"), "SS" },
                    { new Guid("4c6465b8-6861-41d2-8ccb-b968978a2f52"), "Lanzador" },
                    { new Guid("b9a2f3f4-c493-4a5f-bc83-4e307543f405"), "LF" },
                    { new Guid("1ae49d37-92f2-4f34-89b2-8950d54fa999"), "RF" },
                    { new Guid("1e9ff5c1-2ea0-4f58-a0ba-9c543626b080"), "CF" },
                    { new Guid("88c53dfd-6f39-4710-82c2-256f3f35c418"), "BD" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
