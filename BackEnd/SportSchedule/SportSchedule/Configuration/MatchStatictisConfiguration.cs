using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class MatchStatictisConfiguration : IEntityTypeConfiguration<MatchStatictisModel>
    {
        public void Configure(EntityTypeBuilder<MatchStatictisModel> builder)
        {
            builder.ToTable("MatchStatictis");
            builder.HasKey(ms => ms.MatchStatictisId);
            builder.Property(ms => ms.Score).HasDefaultValue(0);
            builder.Property(ms => ms.Possession).HasDefaultValue(50);
            builder.Property(ms => ms.ShortsOnTaget).HasDefaultValue(0);
            builder.Property(ms => ms.Corners).HasDefaultValue(0);
            builder.Property(ms => ms.YellowCard).HasDefaultValue(0);
            builder.Property(ms => ms.RedCard).HasDefaultValue(0);

            //Khoa ngoai giua MatchStatictis va Team
            builder.HasOne(ms => ms.Team)
                .WithMany(t => t.MatchStatictis)
                .HasForeignKey(ms => ms.TeamId);

            //Khoa ngoai giua MatchStatictis va Match
            builder.HasOne(ms => ms.Match)
                .WithMany(m => m.MatchStatictis)
                .HasForeignKey(ms => ms.MatchId);


        }
    }
}
