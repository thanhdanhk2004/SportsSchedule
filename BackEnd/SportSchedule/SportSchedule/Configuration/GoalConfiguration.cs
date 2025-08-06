using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class GoalConfiguration : IEntityTypeConfiguration<GoalModel>
    {
        public void Configure(EntityTypeBuilder<GoalModel> builder)
        {
            builder.ToTable("Goal");
            builder.HasKey(g => g.GoalId);
            builder.Property(g => g.GoalTime).IsRequired();
            builder.Property(g => g.GoalType).HasDefaultValue("Nomal Goal");

            //Khoa ngoai giua Goal va Player
            builder.HasOne(g => g.Player)
                .WithMany(p => p.Goals)
                .HasForeignKey(g => g.PlayerId);

            //Khoa ngoai giua Goal va Team
            builder.HasOne(g => g.Team)
                .WithMany(t => t.Goals)
                .HasForeignKey(g => g.TeamId);

            //Khoa ngoai giua Goal va Match
            builder.HasOne(g => g.Match)
                .WithMany(m => m.Goals)
                .HasForeignKey(g => g.MatchId);

        }
    }
}
