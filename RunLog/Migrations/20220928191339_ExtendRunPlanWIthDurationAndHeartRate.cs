using Microsoft.EntityFrameworkCore.Migrations;

namespace RunLog.Migrations
{
    public partial class ExtendRunPlanWIthDurationAndHeartRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "RunPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeartRate",
                table: "RunPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "RunPlans");

            migrationBuilder.DropColumn(
                name: "HeartRate",
                table: "RunPlans");
        }
    }
}
