using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class PlayerMatchConfiguration : IEntityTypeConfiguration<PlayerMatchModel>
    {
        public void Configure(EntityTypeBuilder<PlayerMatchModel> builder)
        {
            builder.ToTable("PlayerMatch");
            builder.HasKey(pm => new {pm.PlayerId, pm.MatchId});
            builder.Property(pm => pm.Status).IsRequired();

            builder.HasOne(pm => pm.Player)
                .WithMany(p => p.PlayerMatches)
                .HasForeignKey(pm => pm.PlayerId);

            builder.HasOne(pm => pm.Match)
                .WithMany(m => m.PlayerMatches)
                .HasForeignKey(pm =>pm.MatchId);
        }
    }
}
