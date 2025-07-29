using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class alterattributestatustoround : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Match");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 14, 31, 24, 922, DateTimeKind.Utc).AddTicks(6637),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 514, DateTimeKind.Utc).AddTicks(2541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 14, 31, 24, 936, DateTimeKind.Utc).AddTicks(2122),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 532, DateTimeKind.Utc).AddTicks(3257));

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Match",
                type: "text",
                nullable: false,
                defaultValue: "07/28/2025 14:31:24",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "07/28/2025 07:50:24");

            migrationBuilder.AddColumn<string>(
                name: "Round",
                table: "Match",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 14, 31, 24, 977, DateTimeKind.Utc).AddTicks(2871),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 593, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 14, 31, 24, 931, DateTimeKind.Utc).AddTicks(9124),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 527, DateTimeKind.Utc).AddTicks(5590));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Round",
                table: "Match");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 514, DateTimeKind.Utc).AddTicks(2541),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 14, 31, 24, 922, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 532, DateTimeKind.Utc).AddTicks(3257),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 14, 31, 24, 936, DateTimeKind.Utc).AddTicks(2122));

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Match",
                type: "text",
                nullable: false,
                defaultValue: "07/28/2025 07:50:24",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "07/28/2025 14:31:24");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Match",
                type: "text",
                nullable: true,
                defaultValue: "Chưa đá");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 593, DateTimeKind.Utc).AddTicks(4048),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 14, 31, 24, 977, DateTimeKind.Utc).AddTicks(2871));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 28, 7, 50, 24, 527, DateTimeKind.Utc).AddTicks(5590),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 28, 14, 31, 24, 931, DateTimeKind.Utc).AddTicks(9124));
        }
    }
}
