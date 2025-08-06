using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class addrelationshipcardandmember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 400, DateTimeKind.Utc).AddTicks(5205),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 355, DateTimeKind.Utc).AddTicks(7844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 413, DateTimeKind.Utc).AddTicks(6751),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 365, DateTimeKind.Utc).AddTicks(1620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 459, DateTimeKind.Utc).AddTicks(2398),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 410, DateTimeKind.Utc).AddTicks(8155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 409, DateTimeKind.Utc).AddTicks(2280),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 362, DateTimeKind.Utc).AddTicks(1855));

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Card",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_MemberId",
                table: "Card",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Member_MemberId",
                table: "Card",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Member_MemberId",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Card_MemberId",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Card");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 355, DateTimeKind.Utc).AddTicks(7844),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 400, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 365, DateTimeKind.Utc).AddTicks(1620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 413, DateTimeKind.Utc).AddTicks(6751));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 410, DateTimeKind.Utc).AddTicks(8155),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 459, DateTimeKind.Utc).AddTicks(2398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 23, 0, 362, DateTimeKind.Utc).AddTicks(1855),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 409, DateTimeKind.Utc).AddTicks(2280));
        }
    }
}
