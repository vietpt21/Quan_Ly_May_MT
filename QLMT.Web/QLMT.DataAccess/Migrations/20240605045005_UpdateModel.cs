using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLMT.DataAccess.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventotyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Entry_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exit_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Satatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WareHouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventotyId);
                });

         
            migrationBuilder.CreateTable(
                name: "WareHouses",
                columns: table => new
                {
                    WareHouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouses", x => x.WareHouseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "WareHouses");
        }
    }
}
