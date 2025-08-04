using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<PlayerModel>
    {
        public void Configure(EntityTypeBuilder<PlayerModel> builder)
        {
            builder.ToTable("Player");
            builder.HasKey(p => p.PlayerId);
            builder.Property(p => p.Weight).IsRequired();
            builder.Property(p => p.Height).IsRequired();
            builder.Property(p => p.status).IsRequired(false);
    
        }
    }
}
