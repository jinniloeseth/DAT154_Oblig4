using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedActionLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionLog_CaseScenarios_CaseScenarioId",
                table: "ActionLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionLog",
                table: "ActionLog");

            migrationBuilder.RenameTable(
                name: "ActionLog",
                newName: "ActionLogs");

            migrationBuilder.RenameIndex(
                name: "IX_ActionLog_CaseScenarioId",
                table: "ActionLogs",
                newName: "IX_ActionLogs_CaseScenarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Reactions",
                table: "Allergies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionLogs",
                table: "ActionLogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionLogs_CaseScenarios_CaseScenarioId",
                table: "ActionLogs",
                column: "CaseScenarioId",
                principalTable: "CaseScenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionLogs_CaseScenarios_CaseScenarioId",
                table: "ActionLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionLogs",
                table: "ActionLogs");

            migrationBuilder.RenameTable(
                name: "ActionLogs",
                newName: "ActionLog");

            migrationBuilder.RenameIndex(
                name: "IX_ActionLogs_CaseScenarioId",
                table: "ActionLog",
                newName: "IX_ActionLog_CaseScenarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Reactions",
                table: "Allergies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionLog",
                table: "ActionLog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionLog_CaseScenarios_CaseScenarioId",
                table: "ActionLog",
                column: "CaseScenarioId",
                principalTable: "CaseScenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
