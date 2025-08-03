using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class PeriodConfiguration : IEntityTypeConfiguration<PeriodModel>
    {
        public void Configure(EntityTypeBuilder<PeriodModel> builder)
        {
            builder.ToTable("Period");
            builder.HasKey(p => p.PeriodId);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Time).IsRequired();
            builder.Property(p => p.GoalHome).HasDefaultValue(0);
            builder.Property(p => p.GoalAway).HasDefaultValue(0);

            //Khoa ngoai giua Period va Match
            builder.HasOne(p => p.Match)
                .WithMany(m => m.Periods)
                .HasForeignKey(p => p.MatchId);

        }
    }
}
