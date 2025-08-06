using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class updaterelationshipgoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Period_PeriodId",
                table: "Goal");

            migrationBuilder.RenameColumn(
                name: "PeriodId",
                table: "Goal",
                newName: "MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Goal_PeriodId",
                table: "Goal",
                newName: "IX_Goal_MatchId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 468, DateTimeKind.Utc).AddTicks(5309),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 314, DateTimeKind.Utc).AddTicks(1781));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 500, DateTimeKind.Utc).AddTicks(7760),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 332, DateTimeKind.Utc).AddTicks(4253));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 580, DateTimeKind.Utc).AddTicks(1776),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 383, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 492, DateTimeKind.Utc).AddTicks(5244),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 328, DateTimeKind.Utc).AddTicks(9899));

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_Match_MatchId",
                table: "Goal",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "MatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Match_MatchId",
                table: "Goal");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Goal",
                newName: "PeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_Goal_MatchId",
                table: "Goal",
                newName: "IX_Goal_PeriodId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 314, DateTimeKind.Utc).AddTicks(1781),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 468, DateTimeKind.Utc).AddTicks(5309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 332, DateTimeKind.Utc).AddTicks(4253),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 500, DateTimeKind.Utc).AddTicks(7760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 383, DateTimeKind.Utc).AddTicks(1383),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 580, DateTimeKind.Utc).AddTicks(1776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 328, DateTimeKind.Utc).AddTicks(9899),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 492, DateTimeKind.Utc).AddTicks(5244));

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_Period_PeriodId",
                table: "Goal",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "PeriodId");
        }
    }
}
