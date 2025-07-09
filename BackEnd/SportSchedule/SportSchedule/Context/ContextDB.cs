using Microsoft.EntityFrameworkCore;
using SportSchedule.Configuration;
using SportSchedule.Model;
using System.Numerics;

namespace SportSchedule.Context
{
    public class ContextDB:DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options):base(options) { }
        public ContextDB() { }

        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<AccountModel> Accounts { get; set; }
        public virtual DbSet<PostModel> Posts { get; set; }
        public virtual DbSet<CommentModel> Comment { get; set; }
        public virtual DbSet<MessageModel> Messages { get; set; }
        public virtual DbSet<TeamModel> Teams { get; set; }
        public virtual DbSet<MemberModel> Members { get; set; }
        public virtual DbSet<PlayerModel> Players { get; set; }
        public virtual DbSet<TeamMemberModel> TeamMembers { get; set; }
        public virtual DbSet<SeasonModel> Seasons { get; set; }
        public virtual DbSet<LeagueModel> Leagues { get; set; }
        public virtual DbSet<LeagueTeamModel> LeagueTeams { get; set; }
        public virtual DbSet<RankingModel> Rankings { get; set; }
        public virtual DbSet<MatchModel> Matches { get; set; }
        public virtual DbSet<MatchStatictisModel> MatchStatictis { get; set; }
        public virtual DbSet<PeriodModel> Periods { get; set; }
        public virtual DbSet<CardModel> Cards { get; set; }
        public virtual DbSet<GoalModel> Goals { get; set; }
        public virtual DbSet<GuessModel> Guesses { get; set; }
        public virtual DbSet<AwardModel> Awards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamMemberConfiguration());
            modelBuilder.ApplyConfiguration(new SeasonConfiguration());
            modelBuilder.ApplyConfiguration(new LeagueConfiguration());
            modelBuilder.ApplyConfiguration(new LeagueTeamConfiguration());
            modelBuilder.ApplyConfiguration(new RankingConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new MatchStatictisConfiguration());
            modelBuilder.ApplyConfiguration(new PeriodConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new GoalConfiguration());
            modelBuilder.ApplyConfiguration(new GuessConfiguration());
            modelBuilder.ApplyConfiguration(new AwardConfiguration());
        }

    }
}
