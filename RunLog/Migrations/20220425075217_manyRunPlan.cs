using Microsoft.EntityFrameworkCore.Migrations;

namespace RunLog.Migrations
{
    public partial class manyRunPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RunPlan_Users_CreatedById",
                table: "RunPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_Runs_RunPlan_CompletedPlanId",
                table: "Runs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RunPlan_RunPlanId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RunPlan",
                table: "RunPlan");

            migrationBuilder.RenameTable(
                name: "RunPlan",
                newName: "RunPlans");

            migrationBuilder.RenameIndex(
                name: "IX_RunPlan_CreatedById",
                table: "RunPlans",
                newName: "IX_RunPlans_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RunPlans",
                table: "RunPlans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RunPlans_Users_CreatedById",
                table: "RunPlans",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Runs_RunPlans_CompletedPlanId",
                table: "Runs",
                column: "CompletedPlanId",
                principalTable: "RunPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RunPlans_RunPlanId",
                table: "Users",
                column: "RunPlanId",
                principalTable: "RunPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RunPlans_Users_CreatedById",
                table: "RunPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Runs_RunPlans_CompletedPlanId",
                table: "Runs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RunPlans_RunPlanId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RunPlans",
                table: "RunPlans");

            migrationBuilder.RenameTable(
                name: "RunPlans",
                newName: "RunPlan");

            migrationBuilder.RenameIndex(
                name: "IX_RunPlans_CreatedById",
                table: "RunPlan",
                newName: "IX_RunPlan_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RunPlan",
                table: "RunPlan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RunPlan_Users_CreatedById",
                table: "RunPlan",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Runs_RunPlan_CompletedPlanId",
                table: "Runs",
                column: "CompletedPlanId",
                principalTable: "RunPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RunPlan_RunPlanId",
                table: "Users",
                column: "RunPlanId",
                principalTable: "RunPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
