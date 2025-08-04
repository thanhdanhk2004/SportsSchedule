using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class alterrelationshipextend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Member_MemberId",
                table: "Player");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Player",
                newName: "PlayerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 422, DateTimeKind.Utc).AddTicks(3542),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 3, 16, 3, 30, 771, DateTimeKind.Utc).AddTicks(9462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 431, DateTimeKind.Utc).AddTicks(7432),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 3, 16, 3, 30, 792, DateTimeKind.Utc).AddTicks(954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 461, DateTimeKind.Utc).AddTicks(4477),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 3, 16, 3, 30, 847, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 429, DateTimeKind.Utc).AddTicks(5742),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 3, 16, 3, 30, 785, DateTimeKind.Utc).AddTicks(414));

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Member_PlayerId",
                table: "Player",
                column: "PlayerId",
                principalTable: "Member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Member_PlayerId",
                table: "Player");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Player",
                newName: "MemberId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 3, 16, 3, 30, 771, DateTimeKind.Utc).AddTicks(9462),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 422, DateTimeKind.Utc).AddTicks(3542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 3, 16, 3, 30, 792, DateTimeKind.Utc).AddTicks(954),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 431, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 3, 16, 3, 30, 847, DateTimeKind.Utc).AddTicks(5390),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 461, DateTimeKind.Utc).AddTicks(4477));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 3, 16, 3, 30, 785, DateTimeKind.Utc).AddTicks(414),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 4, 8, 55, 43, 429, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Member_MemberId",
                table: "Player",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
