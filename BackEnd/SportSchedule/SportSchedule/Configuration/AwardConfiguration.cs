using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class AwardConfiguration : IEntityTypeConfiguration<AwardModel>
    {
        public void Configure(EntityTypeBuilder<AwardModel> builder)
        {
            builder.ToTable("Award");
            builder.HasKey(a => a.AwardId);
            builder.Property(a => a.Description).IsRequired(false);
            builder.Property(a => a.Gift).IsRequired();
        }
    }
}
