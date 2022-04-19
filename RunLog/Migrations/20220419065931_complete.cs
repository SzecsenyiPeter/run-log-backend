using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RunLog.Migrations
{
    public partial class complete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoachedById",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RunPlanId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompletedPlanId",
                table: "Runs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RanById",
                table: "Runs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RunPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunPlan_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CoachedById",
                table: "Users",
                column: "CoachedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RunPlanId",
                table: "Users",
                column: "RunPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Runs_CompletedPlanId",
                table: "Runs",
                column: "CompletedPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Runs_RanById",
                table: "Runs",
                column: "RanById");

            migrationBuilder.CreateIndex(
                name: "IX_RunPlan_CreatedById",
                table: "RunPlan",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Runs_RunPlan_CompletedPlanId",
                table: "Runs",
                column: "CompletedPlanId",
                principalTable: "RunPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Runs_Users_RanById",
                table: "Runs",
                column: "RanById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RunPlan_RunPlanId",
                table: "Users",
                column: "RunPlanId",
                principalTable: "RunPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CoachedById",
                table: "Users",
                column: "CoachedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runs_RunPlan_CompletedPlanId",
                table: "Runs");

            migrationBuilder.DropForeignKey(
                name: "FK_Runs_Users_RanById",
                table: "Runs");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RunPlan_RunPlanId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CoachedById",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RunPlan");

            migrationBuilder.DropIndex(
                name: "IX_Users_CoachedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RunPlanId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Runs_CompletedPlanId",
                table: "Runs");

            migrationBuilder.DropIndex(
                name: "IX_Runs_RanById",
                table: "Runs");

            migrationBuilder.DropColumn(
                name: "CoachedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RunPlanId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompletedPlanId",
                table: "Runs");

            migrationBuilder.DropColumn(
                name: "RanById",
                table: "Runs");
        }
    }
}
