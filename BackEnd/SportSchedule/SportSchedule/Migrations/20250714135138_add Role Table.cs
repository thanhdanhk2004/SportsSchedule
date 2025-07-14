using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class addRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 14, 13, 51, 37, 552, DateTimeKind.Utc).AddTicks(1146),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 681, DateTimeKind.Utc).AddTicks(5426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 14, 13, 51, 37, 562, DateTimeKind.Utc).AddTicks(5416),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 687, DateTimeKind.Utc).AddTicks(3615));

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Match",
                type: "text",
                nullable: false,
                defaultValue: "07/14/2025 13:51:37",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "07/10/2025 14:33:49");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 14, 13, 51, 37, 611, DateTimeKind.Utc).AddTicks(2244),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 722, DateTimeKind.Utc).AddTicks(8349));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 14, 13, 51, 37, 559, DateTimeKind.Utc).AddTicks(81),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 685, DateTimeKind.Utc).AddTicks(1733));

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                type: "integer",
                nullable: true,
                defaultValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Post",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 681, DateTimeKind.Utc).AddTicks(5426),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 14, 13, 51, 37, 552, DateTimeKind.Utc).AddTicks(1146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 687, DateTimeKind.Utc).AddTicks(3615),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 14, 13, 51, 37, 562, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Match",
                type: "text",
                nullable: false,
                defaultValue: "07/10/2025 14:33:49",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "07/14/2025 13:51:37");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GuessTime",
                table: "Guess",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 722, DateTimeKind.Utc).AddTicks(8349),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 14, 13, 51, 37, 611, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 685, DateTimeKind.Utc).AddTicks(1733),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 7, 14, 13, 51, 37, 559, DateTimeKind.Utc).AddTicks(81));
        }
    }
}
