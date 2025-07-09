using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<TeamModel>
    {
        public void Configure(EntityTypeBuilder<TeamModel> builder)
        {
            builder.ToTable("Team");
            builder.HasKey(t => t.TeamId);
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Country).IsRequired();
            builder.Property(t => t.Logo).IsRequired(false);
            builder.Property(t => t.NameHome).IsRequired(false);
            builder.Property(t => t.TeamType).HasDefaultValue(TeamType.Club);
            
        }
    }
}
