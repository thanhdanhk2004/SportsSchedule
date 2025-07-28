using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class updateLeaguetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 514, DateTimeKind.Utc).AddTicks(2541),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 567, DateTimeKind.Utc).AddTicks(7157));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 532, DateTimeKind.Utc).AddTicks(3257),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 597, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Match",
                type: "text",
                nullable: false,
                defaultValue: "07/28/2025 07:50:24",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "07/24/2025 14:08:19");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "League",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 593, DateTimeKind.Utc).AddTicks(4048),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 652, DateTimeKind.Utc).AddTicks(8928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 527, DateTimeKind.Utc).AddTicks(5590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 581, DateTimeKind.Utc).AddTicks(3820));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "League");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 567, DateTimeKind.Utc).AddTicks(7157),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 514, DateTimeKind.Utc).AddTicks(2541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 597, DateTimeKind.Utc).AddTicks(6933),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 532, DateTimeKind.Utc).AddTicks(3257));

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Match",
                type: "text",
                nullable: false,
                defaultValue: "07/24/2025 14:08:19",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "07/28/2025 07:50:24");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 652, DateTimeKind.Utc).AddTicks(8928),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 593, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 581, DateTimeKind.Utc).AddTicks(3820),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 527, DateTimeKind.Utc).AddTicks(5590));
        }
    }
}
