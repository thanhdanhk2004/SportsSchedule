using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class createtableSubstitution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 428, DateTimeKind.Utc).AddTicks(6171),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 400, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 437, DateTimeKind.Utc).AddTicks(3563),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 413, DateTimeKind.Utc).AddTicks(6751));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 477, DateTimeKind.Utc).AddTicks(1811),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 459, DateTimeKind.Utc).AddTicks(2398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 435, DateTimeKind.Utc).AddTicks(2242),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 409, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.CreateTable(
                name: "Substitution",
                columns: table => new
                {
                    SubId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Time = table.Column<int>(type: "integer", nullable: false),
                    MatchId = table.Column<int>(type: "integer", nullable: true),
                    PlayerInId = table.Column<int>(type: "integer", nullable: true),
                    PlayerOutId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substitution", x => x.SubId);
                    table.ForeignKey(
                        name: "FK_Substitution_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "MatchId");
                    table.ForeignKey(
                        name: "FK_Substitution_Player_PlayerInId",
                        column: x => x.PlayerInId,
                        principalTable: "Player",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_Substitution_Player_PlayerOutId",
                        column: x => x.PlayerOutId,
                        principalTable: "Player",
                        principalColumn: "PlayerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Substitution_MatchId",
                table: "Substitution",
                column: "MatchId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Substitution");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 400, DateTimeKind.Utc).AddTicks(5205),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 428, DateTimeKind.Utc).AddTicks(6171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 413, DateTimeKind.Utc).AddTicks(6751),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 437, DateTimeKind.Utc).AddTicks(3563));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 459, DateTimeKind.Utc).AddTicks(2398),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 477, DateTimeKind.Utc).AddTicks(1811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 6, 15, 36, 47, 409, DateTimeKind.Utc).AddTicks(2280),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 9, 14, 43, 14, 435, DateTimeKind.Utc).AddTicks(2242));
        }
    }
}
