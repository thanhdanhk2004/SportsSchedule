using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSchedule.Migrations
{
    /// <inheritdoc />
    public partial class createdatabasefootball : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    SeasonId = table.Column<string>(type: "text", nullable: false),
                    SeasonYear = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.SeasonId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    NameHome = table.Column<string>(type: "text", nullable: true),
                    TeamType = table.Column<int>(type: "integer", nullable: true, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: true, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Player_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    LeagueId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    SeasonId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.LeagueId);
                    table.ForeignKey(
                        name: "FK_League_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "SeasonId");
                });

            migrationBuilder.CreateTable(
                name: "TeamMember",
                columns: table => new
                {
                    TeamId = table.Column<string>(type: "text", nullable: false),
                    MemberId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMember", x => new { x.MemberId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_TeamMember_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMember_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true, defaultValue: "string"),
                    Image = table.Column<string>(type: "text", nullable: false),
                    SendTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 687, DateTimeKind.Utc).AddTicks(3615)),
                    UserIdSend = table.Column<string>(type: "text", nullable: true),
                    UserIdRevice = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 681, DateTimeKind.Utc).AddTicks(5426)),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "LeagueTeam",
                columns: table => new
                {
                    LeagueId = table.Column<string>(type: "text", nullable: false),
                    TeamId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueTeam", x => new { x.LeagueId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_LeagueTeam_League_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "League",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeagueTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchId = table.Column<string>(type: "text", nullable: false),
                    Venue = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false, defaultValue: "07/10/2025 14:33:49"),
                    Status = table.Column<string>(type: "text", nullable: true, defaultValue: "Chưa đá"),
                    TeamIdHome = table.Column<string>(type: "text", nullable: true),
                    TeamIdAway = table.Column<string>(type: "text", nullable: true),
                    SeasonId = table.Column<string>(type: "text", nullable: true),
                    LeagueId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Match_League_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "League",
                        principalColumn: "LeagueId");
                    table.ForeignKey(
                        name: "FK_Match_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "SeasonId");
                    table.ForeignKey(
                        name: "FK_Match_Team_TeamIdAway",
                        column: x => x.TeamIdAway,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                    table.ForeignKey(
                        name: "FK_Match_Team_TeamIdHome",
                        column: x => x.TeamIdHome,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    RankingId = table.Column<string>(type: "text", nullable: false),
                    Played = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Win = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Draw = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Loss = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    GoalsFor = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    GoalsAgainst = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    GoalDifference = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Point = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Position = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    TeamId = table.Column<string>(type: "text", nullable: true),
                    LeagueId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.RankingId);
                    table.ForeignKey(
                        name: "FK_Ranking_League_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "League",
                        principalColumn: "LeagueId");
                    table.ForeignKey(
                        name: "FK_Ranking_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 685, DateTimeKind.Utc).AddTicks(1733)),
                    PostId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CommendIdReply = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_CommendIdReply",
                        column: x => x.CommendIdReply,
                        principalTable: "Comment",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId");
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Guess",
                columns: table => new
                {
                    GuessId = table.Column<string>(type: "text", nullable: false),
                    GuessTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValue: new DateTime(2025, 7, 10, 14, 33, 49, 722, DateTimeKind.Utc).AddTicks(8349)),
                    PredictHomeScore = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                    PredictAwayScore = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                    MatchId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guess", x => x.GuessId);
                    table.ForeignKey(
                        name: "FK_Guess_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "MatchId");
                    table.ForeignKey(
                        name: "FK_Guess_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "MatchStatictis",
                columns: table => new
                {
                    MatchStatictisId = table.Column<string>(type: "text", nullable: false),
                    Score = table.Column<string>(type: "text", nullable: true, defaultValue: "0"),
                    Possession = table.Column<string>(type: "text", nullable: true, defaultValue: "50"),
                    ShortsOnTaget = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                    Corners = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                    YellowCard = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                    RedCard = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                    TeamId = table.Column<string>(type: "text", nullable: true),
                    MatchId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatictis", x => x.MatchStatictisId);
                    table.ForeignKey(
                        name: "FK_MatchStatictis_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "MatchId");
                    table.ForeignKey(
                        name: "FK_MatchStatictis_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    PeriodId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MatchId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.PeriodId);
                    table.ForeignKey(
                        name: "FK_Period_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "MatchId");
                });

            migrationBuilder.CreateTable(
                name: "Award",
                columns: table => new
                {
                    AwardId = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Gift = table.Column<string>(type: "text", nullable: false),
                    GuessId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Award", x => x.AwardId);
                    table.ForeignKey(
                        name: "FK_Award_Guess_GuessId",
                        column: x => x.GuessId,
                        principalTable: "Guess",
                        principalColumn: "GuessId");
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardId = table.Column<string>(type: "text", nullable: false),
                    TypeCard = table.Column<string>(type: "text", nullable: true, defaultValue: "Card Yellow"),
                    Time = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true, defaultValue: "valid"),
                    PeriodId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Card_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "PeriodId");
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    GoalId = table.Column<string>(type: "text", nullable: false),
                    GoalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GoalType = table.Column<string>(type: "text", nullable: true, defaultValue: "Nomal"),
                    PlayerId = table.Column<string>(type: "text", nullable: true),
                    TeamId = table.Column<string>(type: "text", nullable: true),
                    PeriodId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.GoalId);
                    table.ForeignKey(
                        name: "FK_Goal_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "PeriodId");
                    table.ForeignKey(
                        name: "FK_Goal_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "MemberId");
                    table.ForeignKey(
                        name: "FK_Goal_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserId",
                table: "Account",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserName",
                table: "Account",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Award_GuessId",
                table: "Award",
                column: "GuessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_PeriodId",
                table: "Card",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommendIdReply",
                table: "Comment",
                column: "CommendIdReply");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_PeriodId",
                table: "Goal",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_PlayerId",
                table: "Goal",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_TeamId",
                table: "Goal",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Guess_MatchId",
                table: "Guess",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Guess_UserId",
                table: "Guess",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_League_SeasonId",
                table: "League",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueTeam_TeamId",
                table: "LeagueTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_LeagueId",
                table: "Match",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_SeasonId",
                table: "Match",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TeamIdAway",
                table: "Match",
                column: "TeamIdAway");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TeamIdHome",
                table: "Match",
                column: "TeamIdHome");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatictis_MatchId",
                table: "MatchStatictis",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatictis_TeamId",
                table: "MatchStatictis",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserIdRevice",
                table: "Message",
                column: "UserIdRevice");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserIdSend",
                table: "Message",
                column: "UserIdSend");

            migrationBuilder.CreateIndex(
                name: "IX_Period_MatchId",
                table: "Period",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_LeagueId",
                table: "Ranking",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_TeamId",
                table: "Ranking",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_TeamId",
                table: "TeamMember",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Award");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "LeagueTeam");

            migrationBuilder.DropTable(
                name: "MatchStatictis");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "TeamMember");

            migrationBuilder.DropTable(
                name: "Guess");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "League");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Season");
        }
    }
}
