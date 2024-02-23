using Microsoft.EntityFrameworkCore.Migrations;

namespace Tadbir.MMP.Migrations
{
    public partial class chck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReqDetails_InsuranceTypes_InsuranceTypeId",
                table: "ReqDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReqDetails_InsuranceTypeId",
                table: "ReqDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReqDetails_InsuranceTypeId",
                table: "ReqDetails",
                column: "InsuranceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReqDetails_InsuranceTypes_InsuranceTypeId",
                table: "ReqDetails",
                column: "InsuranceTypeId",
                principalTable: "InsuranceTypes",
                principalColumn: "InsuranceTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
