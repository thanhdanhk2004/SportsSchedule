using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class updaterelationshipcard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Period_PeriodId",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "PeriodId",
                table: "Card",
                newName: "MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Card_PeriodId",
                table: "Card",
                newName: "IX_Card_MatchId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 314, DateTimeKind.Utc).AddTicks(1781),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 422, DateTimeKind.Utc).AddTicks(3542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 332, DateTimeKind.Utc).AddTicks(4253),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 431, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 383, DateTimeKind.Utc).AddTicks(1383),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 461, DateTimeKind.Utc).AddTicks(4477));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 328, DateTimeKind.Utc).AddTicks(9899),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 429, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Match_MatchId",
                table: "Card",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "MatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Match_MatchId",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Card",
                newName: "PeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_Card_MatchId",
                table: "Card",
                newName: "IX_Card_PeriodId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 422, DateTimeKind.Utc).AddTicks(3542),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 314, DateTimeKind.Utc).AddTicks(1781));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 431, DateTimeKind.Utc).AddTicks(7432),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 332, DateTimeKind.Utc).AddTicks(4253));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 461, DateTimeKind.Utc).AddTicks(4477),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 383, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 429, DateTimeKind.Utc).AddTicks(5742),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 9, 30, 328, DateTimeKind.Utc).AddTicks(9899));

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Period_PeriodId",
                table: "Card",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "PeriodId");
        }
    }
}
