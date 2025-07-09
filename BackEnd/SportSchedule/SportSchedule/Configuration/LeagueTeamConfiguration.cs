using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class LeagueTeamConfiguration : IEntityTypeConfiguration<LeagueTeamModel>
    {
        public void Configure(EntityTypeBuilder<LeagueTeamModel> builder)
        {
            builder.ToTable("LeagueTeam");
            builder.HasKey(lt => new { lt.LeagueId, lt.TeamId });

            //Thiet lap khoa ngoai
            builder.HasOne(lt => lt.League)
                .WithMany(l => l.LeagueTeams)
                .HasForeignKey(lt => lt.LeagueId);

            builder.HasOne(lt => lt.Team)
                .WithMany(t => t.LeagueTeams)
                .HasForeignKey(lt => lt.TeamId);
        }
    }
}
