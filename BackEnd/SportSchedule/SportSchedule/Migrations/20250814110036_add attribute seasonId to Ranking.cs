using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class addattributeseasonIdtoRanking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Ranking",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 14, 11, 0, 35, 82, DateTimeKind.Utc).AddTicks(4604),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 433, DateTimeKind.Utc).AddTicks(3538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 14, 11, 0, 35, 91, DateTimeKind.Utc).AddTicks(2092),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 450, DateTimeKind.Utc).AddTicks(4044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 14, 11, 0, 35, 144, DateTimeKind.Utc).AddTicks(2909),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 507, DateTimeKind.Utc).AddTicks(5760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 14, 11, 0, 35, 89, DateTimeKind.Utc).AddTicks(10),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 444, DateTimeKind.Utc).AddTicks(4496));

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_SeasonId",
                table: "Ranking",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranking_Season_SeasonId",
                table: "Ranking",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "SeasonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranking_Season_SeasonId",
                table: "Ranking");

            migrationBuilder.DropIndex(
                name: "IX_Ranking_SeasonId",
                table: "Ranking");

            migrationBuilder.DropColumn(
                name: "SeasonId",
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
                oldDefaultValue: new DateTime(2025, 8, 14, 11, 0, 35, 82, DateTimeKind.Utc).AddTicks(4604));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 450, DateTimeKind.Utc).AddTicks(4044),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 14, 11, 0, 35, 91, DateTimeKind.Utc).AddTicks(2092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 507, DateTimeKind.Utc).AddTicks(5760),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 14, 11, 0, 35, 144, DateTimeKind.Utc).AddTicks(2909));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 14, 3, 50, 40, 444, DateTimeKind.Utc).AddTicks(4496),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 14, 11, 0, 35, 89, DateTimeKind.Utc).AddTicks(10));
        }
    }
}
