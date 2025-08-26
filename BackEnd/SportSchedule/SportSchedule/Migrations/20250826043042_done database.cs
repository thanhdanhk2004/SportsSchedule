using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class donedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 26, 4, 30, 41, 339, DateTimeKind.Utc).AddTicks(4148),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 23, 9, 49, 21, 969, DateTimeKind.Utc).AddTicks(7174));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 26, 4, 30, 41, 374, DateTimeKind.Utc).AddTicks(6896),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 23, 9, 49, 22, 17, DateTimeKind.Utc).AddTicks(4045));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 26, 4, 30, 41, 345, DateTimeKind.Utc).AddTicks(3572),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 23, 9, 49, 21, 979, DateTimeKind.Utc).AddTicks(675));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeAward",
                table: "Award",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 26, 4, 30, 41, 375, DateTimeKind.Utc).AddTicks(9702),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 23, 9, 49, 22, 18, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSend",
                table: "Appointment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 26, 4, 30, 41, 384, DateTimeKind.Utc).AddTicks(5280),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 23, 9, 49, 22, 28, DateTimeKind.Utc).AddTicks(5036));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 23, 9, 49, 21, 969, DateTimeKind.Utc).AddTicks(7174),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 26, 4, 30, 41, 339, DateTimeKind.Utc).AddTicks(4148));

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 23, 9, 49, 22, 17, DateTimeKind.Utc).AddTicks(4045),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 26, 4, 30, 41, 374, DateTimeKind.Utc).AddTicks(6896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 23, 9, 49, 21, 979, DateTimeKind.Utc).AddTicks(675),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 26, 4, 30, 41, 345, DateTimeKind.Utc).AddTicks(3572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeAward",
                table: "Award",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 23, 9, 49, 22, 18, DateTimeKind.Utc).AddTicks(4200),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 26, 4, 30, 41, 375, DateTimeKind.Utc).AddTicks(9702));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSend",
                table: "Appointment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 8, 23, 9, 49, 22, 28, DateTimeKind.Utc).AddTicks(5036),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 8, 26, 4, 30, 41, 384, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserIdRevice = table.Column<int>(type: "integer", nullable: true),
                    UserIdSend = table.Column<int>(type: "integer", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    SendTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2025, 8, 23, 9, 49, 21, 982, DateTimeKind.Utc).AddTicks(528)),
                    Type = table.Column<string>(type: "text", nullable: true, defaultValue: "string")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_User_UserIdRevice",
                        column: x => x.UserIdRevice,
                        principalTable: "User",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Message_User_UserIdSend",
                        column: x => x.UserIdSend,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserIdRevice",
                table: "Message",
                column: "UserIdRevice");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserIdSend",
                table: "Message",
                column: "UserIdSend");
        }
    }
}
