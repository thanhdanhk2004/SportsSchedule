using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class SeasonConfiguration : IEntityTypeConfiguration<SeasonModel>
    {
        public void Configure(EntityTypeBuilder<SeasonModel> builder)
        {
            builder.ToTable("Season");
            builder.HasKey(s => s.SeasonId);
            builder.Property(s => s.SeasonYear).IsRequired();

        }
    }
}
