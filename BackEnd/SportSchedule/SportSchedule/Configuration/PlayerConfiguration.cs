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
            builder.Property(p => p.Weight).IsRequired();
            builder.Property(p => p.Height).IsRequired();
            builder.Property(p => p.value).IsRequired(false);
            builder.Property(p => p.status).IsRequired(false);

            
        }
    }
}
