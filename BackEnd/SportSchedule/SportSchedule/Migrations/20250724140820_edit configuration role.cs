using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class editconfigurationrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 567, DateTimeKind.Utc).AddTicks(7157),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 23, 14, 5, 15, 892, DateTimeKind.Utc).AddTicks(5533));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 597, DateTimeKind.Utc).AddTicks(6933),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 23, 14, 5, 15, 903, DateTimeKind.Utc).AddTicks(560));

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Match",
                type: "text",
                nullable: false,
                defaultValue: "07/24/2025 14:08:19",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "07/23/2025 14:05:15");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 652, DateTimeKind.Utc).AddTicks(8928),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 23, 14, 5, 15, 938, DateTimeKind.Utc).AddTicks(1493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 581, DateTimeKind.Utc).AddTicks(3820),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 23, 14, 5, 15, 900, DateTimeKind.Utc).AddTicks(4637));

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 23, 14, 5, 15, 892, DateTimeKind.Utc).AddTicks(5533),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 567, DateTimeKind.Utc).AddTicks(7157));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 23, 14, 5, 15, 903, DateTimeKind.Utc).AddTicks(560),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 597, DateTimeKind.Utc).AddTicks(6933));

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Match",
                type: "text",
                nullable: false,
                defaultValue: "07/23/2025 14:05:15",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "07/24/2025 14:08:19");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 23, 14, 5, 15, 938, DateTimeKind.Utc).AddTicks(1493),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 652, DateTimeKind.Utc).AddTicks(8928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 23, 14, 5, 15, 900, DateTimeKind.Utc).AddTicks(4637),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 24, 14, 8, 19, 581, DateTimeKind.Utc).AddTicks(3820));

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId",
                unique: true);
        }
    }
}
