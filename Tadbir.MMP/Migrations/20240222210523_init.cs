using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tadbir.MMP.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceTypes",
                columns: table => new
                {
                    InsuranceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinInsuranceCoverage = table.Column<int>(type: "int", nullable: false),
                    MaxInsuranceCoverage = table.Column<int>(type: "int", nullable: false),
                    InsuranceRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceTypes", x => x.InsuranceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    ToDoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetInsurancePremium = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.ToDoId);
                });

            migrationBuilder.InsertData(
                table: "InsuranceTypes",
                columns: new[] { "InsuranceTypeId", "InsuranceRate", "MaxInsuranceCoverage", "MinInsuranceCoverage", "Name" },
                values: new object[] { 1, 0.0041999999999999997, 400000000, 4000, "دندان پزشکی" });

            migrationBuilder.InsertData(
                table: "InsuranceTypes",
                columns: new[] { "InsuranceTypeId", "InsuranceRate", "MaxInsuranceCoverage", "MinInsuranceCoverage", "Name" },
                values: new object[] { 2, 0.0051999999999999998, 500000000, 5000, "جراحی" });

            migrationBuilder.InsertData(
                table: "InsuranceTypes",
                columns: new[] { "InsuranceTypeId", "InsuranceRate", "MaxInsuranceCoverage", "MinInsuranceCoverage", "Name" },
                values: new object[] { 3, 0.0050000000000000001, 200000000, 2000, "بستری" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceTypes");

            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
