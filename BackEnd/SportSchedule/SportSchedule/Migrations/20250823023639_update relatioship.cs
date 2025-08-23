using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class updaterelatioship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Substitution_PlayerInId",
                table: "Substitution");

            migrationBuilder.DropIndex(
                name: "IX_Substitution_PlayerOutId",
                table: "Substitution");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 23, 2, 36, 38, 301, DateTimeKind.Utc).AddTicks(4022),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 22, 15, 55, 58, 267, DateTimeKind.Utc).AddTicks(5025));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 23, 2, 36, 38, 314, DateTimeKind.Utc).AddTicks(1632),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 22, 15, 55, 58, 292, DateTimeKind.Utc).AddTicks(741));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 23, 2, 36, 38, 365, DateTimeKind.Utc).AddTicks(3757),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 22, 15, 55, 58, 381, DateTimeKind.Utc).AddTicks(6188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 23, 2, 36, 38, 310, DateTimeKind.Utc).AddTicks(6502),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 22, 15, 55, 58, 283, DateTimeKind.Utc).AddTicks(6591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSend",
                table: "Appointment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 23, 2, 36, 38, 385, DateTimeKind.Utc).AddTicks(3214),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 22, 15, 55, 58, 396, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.CreateIndex(
                name: "IX_Substitution_PlayerInId",
                table: "Substitution",
                column: "PlayerInId");

            migrationBuilder.CreateIndex(
                name: "IX_Substitution_PlayerOutId",
                table: "Substitution",
                column: "PlayerOutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Substitution_PlayerInId",
                table: "Substitution");

            migrationBuilder.DropIndex(
                name: "IX_Substitution_PlayerOutId",
                table: "Substitution");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 22, 15, 55, 58, 267, DateTimeKind.Utc).AddTicks(5025),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 23, 2, 36, 38, 301, DateTimeKind.Utc).AddTicks(4022));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 22, 15, 55, 58, 292, DateTimeKind.Utc).AddTicks(741),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 23, 2, 36, 38, 314, DateTimeKind.Utc).AddTicks(1632));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 22, 15, 55, 58, 381, DateTimeKind.Utc).AddTicks(6188),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 23, 2, 36, 38, 365, DateTimeKind.Utc).AddTicks(3757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 22, 15, 55, 58, 283, DateTimeKind.Utc).AddTicks(6591),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 23, 2, 36, 38, 310, DateTimeKind.Utc).AddTicks(6502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSend",
                table: "Appointment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 22, 15, 55, 58, 396, DateTimeKind.Utc).AddTicks(4317),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 23, 2, 36, 38, 385, DateTimeKind.Utc).AddTicks(3214));

            migrationBuilder.CreateIndex(
                name: "IX_Substitution_PlayerInId",
                table: "Substitution",
                column: "PlayerInId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Substitution_PlayerOutId",
                table: "Substitution",
                column: "PlayerOutId",
                unique: true);
        }
    }
}
