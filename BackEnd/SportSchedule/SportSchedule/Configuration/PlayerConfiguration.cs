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

            //Khoa ngoai voi PlayerIn va PlayerOut
            builder.HasOne(p => p.SubstitutionIn)
                .WithOne(s => s.PlayerIn)
                .HasForeignKey<SubstitutionModel>(s => s.PlayerInId);

            builder.HasOne(p => p.SubstitutionOut)
                .WithOne(s => s.PlayerOut)
                .HasForeignKey<SubstitutionModel>(s => s.PlayerOutId);
        }
    }
}
