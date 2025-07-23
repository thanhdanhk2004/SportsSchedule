using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class LeagueSeasonConfiguration : IEntityTypeConfiguration<LeagueSeasonModel>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonModel> builder)
        {
            builder.ToTable("LeagueSeason");
            builder.HasKey(ls => new {ls.LeagueId, ls.SeasonId});

            //Khoa ngoai
            builder.HasOne(ls => ls.League)
                .WithMany(l => l.LeagueSeasons)
                .HasForeignKey(ls => ls.LeagueId);

            builder.HasOne(ls => ls.Season)
                .WithMany(s => s.LeagueSeasons)
                .HasForeignKey(ls => ls.SeasonId);
        }
    }
}
