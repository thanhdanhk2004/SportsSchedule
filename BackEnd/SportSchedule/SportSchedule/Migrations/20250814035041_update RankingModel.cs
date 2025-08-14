using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class updateRankingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalDifference",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "GoalsAgainst",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "GoalsFor",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Ranking");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 433, DateTimeKind.Utc).AddTicks(3538),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 11, 13, 14, 13, 987, DateTimeKind.Utc).AddTicks(2529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 450, DateTimeKind.Utc).AddTicks(4044),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 11, 13, 14, 14, 0, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 507, DateTimeKind.Utc).AddTicks(5760),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 11, 13, 14, 14, 44, DateTimeKind.Utc).AddTicks(1026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 444, DateTimeKind.Utc).AddTicks(4496),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 11, 13, 14, 13, 997, DateTimeKind.Utc).AddTicks(2450));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalDifference",
                table: "Ranking",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsAgainst",
                table: "Ranking",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsFor",
                table: "Ranking",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Ranking",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 11, 13, 14, 13, 987, DateTimeKind.Utc).AddTicks(2529),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 433, DateTimeKind.Utc).AddTicks(3538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 11, 13, 14, 14, 0, DateTimeKind.Utc).AddTicks(5936),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 450, DateTimeKind.Utc).AddTicks(4044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 11, 13, 14, 14, 44, DateTimeKind.Utc).AddTicks(1026),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 507, DateTimeKind.Utc).AddTicks(5760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 11, 13, 14, 13, 997, DateTimeKind.Utc).AddTicks(2450),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 444, DateTimeKind.Utc).AddTicks(4496));
        }
    }
}
