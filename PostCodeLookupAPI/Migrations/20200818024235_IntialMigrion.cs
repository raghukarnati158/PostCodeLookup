using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostCodeLookupAPI.Migrations
{
    public partial class IntialMigrion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostCodeLookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCode = table.Column<string>(nullable: true),
                    DeliveryInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCodeLookup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PostCodeLookup",
                columns: new[] { "Id", "DeliveryInfo", "PostCode" },
                values: new object[,]
                {
                    { 1, "Delivery from Warehouse", "TN9" },
                    { 2, "No Deliveries", "TN9 1AP" },
                    { 3, "Delivery from Warehouse", "TN8" },
                    { 4, "Delivery from Warehouse", "TN11" },
                    { 5, "Van Delivery, Collect from Tunbridge Wells", "TN1" },
                    { 6, "Van Delivery, Collect from Tunbridge Wells", "TN2" },
                    { 7, "Van Delivery", "TN10" },
                    { 8, "Delivery from Sevenoaks, Collect from Sevenoaks", "TN13" },
                    { 9, "Delivery from Sevenoaks, Collect from Sevenoaks", "TN14" },
                    { 10, "Collect from Sevenoaks", "TN15" },
                    { 11, "No Deliveries", "ME" },
                    { 12, "Collect from Kitchen", "ME10" },
                    { 13, "Collect from Kitchen, Delivery from Sittingbourne", "ME10 3" },
                    { 14, "No Deliveries", "IV" },
                    { 15, "Delivery by Courier", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCodeLookup");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
