using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CustomerCity = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CustomerState = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CustomerPostal = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerManager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentPage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TechName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentPage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductManager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechManager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TechEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechManager", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerManager");

            migrationBuilder.DropTable(
                name: "IncidentPage");

            migrationBuilder.DropTable(
                name: "ProductManager");

            migrationBuilder.DropTable(
                name: "TechManager");
        }
    }
}
