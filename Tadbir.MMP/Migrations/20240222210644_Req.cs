using Microsoft.EntityFrameworkCore.Migrations;

namespace Tadbir.MMP.Migrations
{
    public partial class Req : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReqDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoId = table.Column<int>(type: "int", nullable: false),
                    InsuranceTypeId = table.Column<int>(type: "int", nullable: false),
                    RequestInsuranceCoverage = table.Column<int>(type: "int", nullable: false),
                    NetInsurancePremiumItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReqDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReqDetails_InsuranceTypes_InsuranceTypeId",
                        column: x => x.InsuranceTypeId,
                        principalTable: "InsuranceTypes",
                        principalColumn: "InsuranceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReqDetails_ToDos_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDos",
                        principalColumn: "ToDoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReqDetails_InsuranceTypeId",
                table: "ReqDetails",
                column: "InsuranceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReqDetails_ToDoId",
                table: "ReqDetails",
                column: "ToDoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReqDetails");
        }
    }
}
