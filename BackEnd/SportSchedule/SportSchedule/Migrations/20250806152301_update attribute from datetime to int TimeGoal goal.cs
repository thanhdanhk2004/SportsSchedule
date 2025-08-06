using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class updateattributefromdatetimetointTimeGoalgoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalDate",
                table: "Goal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 355, DateTimeKind.Utc).AddTicks(7844),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 468, DateTimeKind.Utc).AddTicks(5309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 365, DateTimeKind.Utc).AddTicks(1620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 500, DateTimeKind.Utc).AddTicks(7760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 410, DateTimeKind.Utc).AddTicks(8155),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 580, DateTimeKind.Utc).AddTicks(1776));

            migrationBuilder.AlterColumn<string>(
                name: "GoalType",
                table: "Goal",
                type: "text",
                nullable: true,
                defaultValue: "Nomal Goal",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "Nomal");

            migrationBuilder.AddColumn<int>(
                name: "GoalTime",
                table: "Goal",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 362, DateTimeKind.Utc).AddTicks(1855),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 492, DateTimeKind.Utc).AddTicks(5244));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalTime",
                table: "Goal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 468, DateTimeKind.Utc).AddTicks(5309),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 355, DateTimeKind.Utc).AddTicks(7844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 500, DateTimeKind.Utc).AddTicks(7760),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 365, DateTimeKind.Utc).AddTicks(1620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 580, DateTimeKind.Utc).AddTicks(1776),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 410, DateTimeKind.Utc).AddTicks(8155));

            migrationBuilder.AlterColumn<string>(
                name: "GoalType",
                table: "Goal",
                type: "text",
                nullable: true,
                defaultValue: "Nomal",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "Nomal Goal");

            migrationBuilder.AddColumn<DateTime>(
                name: "GoalDate",
                table: "Goal",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 18, 56, 492, DateTimeKind.Utc).AddTicks(5244),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 362, DateTimeKind.Utc).AddTicks(1855));
        }
    }
}
