using Microsoft.EntityFrameworkCore.Migrations;

namespace RunLog.Migrations
{
    public partial class RunPlanAssigments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_RunPlans_RunPlanId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RunPlanId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RunPlanId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "RunPlanAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RunPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunPlanAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunPlanAssignments_RunPlans_RunPlanId",
                        column: x => x.RunPlanId,
                        principalTable: "RunPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RunPlanAssignments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RunPlanAssignments_RunPlanId",
                table: "RunPlanAssignments",
                column: "RunPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_RunPlanAssignments_UserId",
                table: "RunPlanAssignments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunPlanAssignments");

            migrationBuilder.AddColumn<int>(
                name: "RunPlanId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RunPlanId",
                table: "Users",
                column: "RunPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RunPlans_RunPlanId",
                table: "Users",
                column: "RunPlanId",
                principalTable: "RunPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
