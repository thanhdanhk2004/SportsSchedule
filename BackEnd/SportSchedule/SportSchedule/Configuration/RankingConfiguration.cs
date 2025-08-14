using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class RankingConfiguration : IEntityTypeConfiguration<RankingModel>
    {
        public void Configure(EntityTypeBuilder<RankingModel> builder)
        {
            builder.ToTable("Ranking");
            builder.HasKey(r => r.RankingId);
            builder.Property(r => r.Played).IsRequired().HasDefaultValue(0);
            builder.Property(r => r.Win).IsRequired().HasDefaultValue(0);
            builder.Property(r => r.Draw).IsRequired().HasDefaultValue(0);
            builder.Property(r => r.Loss).IsRequired().HasDefaultValue(0);
            builder.Property(r => r.Point).IsRequired().HasDefaultValue(0);
            builder.Property(r => r.Difference).IsRequired().HasDefaultValue(0);
            //Khoa ngoai giua Ranking va Team 
            builder.HasOne(r => r.Team)
                .WithMany(t => t.Rankings)
                .HasForeignKey(r => r.TeamId);

            //Khoa ngoai giua Ranking va League
            builder.HasOne(r => r.League)
                .WithMany(l => l.Rankings)
                .HasForeignKey(r => r.LeagueId);

            //KHoa ngoai giua Ranking va Season
            builder.HasOne(r => r.Season)
                .WithMany(s => s.Rankings)
                .HasForeignKey(r => r.SeasonId);

        }
    }
}
