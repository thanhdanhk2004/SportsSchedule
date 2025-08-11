using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnlineuptotablematchstatistic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 11, 13, 14, 13, 987, DateTimeKind.Utc).AddTicks(2529),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 428, DateTimeKind.Utc).AddTicks(6171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 11, 13, 14, 14, 0, DateTimeKind.Utc).AddTicks(5936),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 437, DateTimeKind.Utc).AddTicks(3563));

            migrationBuilder.AddColumn<string>(
                name: "Lineup",
                table: "MatchStatictis",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 11, 13, 14, 14, 44, DateTimeKind.Utc).AddTicks(1026),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 477, DateTimeKind.Utc).AddTicks(1811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 11, 13, 14, 13, 997, DateTimeKind.Utc).AddTicks(2450),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 435, DateTimeKind.Utc).AddTicks(2242));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lineup",
                table: "MatchStatictis");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 428, DateTimeKind.Utc).AddTicks(6171),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 11, 13, 14, 13, 987, DateTimeKind.Utc).AddTicks(2529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 437, DateTimeKind.Utc).AddTicks(3563),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 11, 13, 14, 14, 0, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 477, DateTimeKind.Utc).AddTicks(1811),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 11, 13, 14, 14, 44, DateTimeKind.Utc).AddTicks(1026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 435, DateTimeKind.Utc).AddTicks(2242),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 11, 13, 14, 13, 997, DateTimeKind.Utc).AddTicks(2450));
        }
    }
}
