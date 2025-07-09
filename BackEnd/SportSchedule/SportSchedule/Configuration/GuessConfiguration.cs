using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class GuessConfiguration : IEntityTypeConfiguration<GuessModel>
    {
        public void Configure(EntityTypeBuilder<GuessModel> builder)
        {
            builder.ToTable("Guess");
            builder.HasKey(g => g.GuessId);
            builder.Property(g => g.GuessTime).HasDefaultValue(DateTime.Now);
            builder.Property(g => g.PredictHomeScore).HasDefaultValue(0);
            builder.Property(g => g.PredictAwayScore).HasDefaultValue(0);

            //Khoa ngoai giua Guess va Match
            builder.HasOne(g => g.Match)
                .WithMany(m => m.Guess)
                .HasForeignKey(g => g.MatchId);

            //Khoa ngoai giua Guess va User
            builder.HasOne(g => g.User)
                .WithMany(u => u.Guess)
                .HasForeignKey(g => g.UserId);

            //Khoa ngoai giua Guess va Award
            builder.HasOne(g => g.Award)
                .WithOne(a => a.Guess)
                .HasForeignKey<AwardModel>(a => a.GuessId);
        }
    }
}
