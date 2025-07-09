using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class LeagueConfiguration : IEntityTypeConfiguration<LeagueModel>
    {
        public void Configure(EntityTypeBuilder<LeagueModel> builder)
        {
            builder.ToTable("League");
            builder.HasKey(l => l.LeagueId);
            builder.Property(l => l.Name).IsRequired();
            builder.Property(l => l.Country).IsRequired();
            builder.Property(l => l.Logo).IsRequired(false);

            //Khoa ngoai giua League va Season
            builder.HasOne(l => l.Season)
                .WithMany(s => s.Leagues)
                .HasForeignKey(l => l.SeasonId);




        }
    }
}
