using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class MatchConfiguration : IEntityTypeConfiguration<MatchModel>
    {
        public void Configure(EntityTypeBuilder<MatchModel> builder)
        {
            builder.ToTable("Match");
            builder.HasKey(m => m.MatchId);
            builder.Property(m => m.Venue).IsRequired();
            builder.Property(m => m.Time).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(m => m.Status).HasDefaultValue("Chưa đá");

            //Khoa ngoai giua Match va TeamHome, TeamAway
            builder.HasOne(m => m.TeamHome)
                .WithMany(t => t.MatchTeamHomes)
                .HasForeignKey(m => m.TeamIdHome);

            builder.HasOne(m => m.TeamAway)
                .WithMany(t => t.MatchTeamAways)
                .HasForeignKey(m => m.TeamIdAway);

            //Thiet lap khoa ngoai giua Match va Season
            builder.HasOne(m => m.Season)
                .WithMany(s => s.Matchs)
                .HasForeignKey(m => m.SeasonId);

            //Khoa ngoai giua Match va League
            builder.HasOne(m => m.League)
                .WithMany(l => l.Matchs)
                .HasForeignKey(m => m.LeagueId);
        }
    }
}
