using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class CardConfiguration : IEntityTypeConfiguration<CardModel>
    {
        public void Configure(EntityTypeBuilder<CardModel> builder)
        {
            builder.ToTable("Card");
            builder.HasKey(c => c.CardId);
            builder.Property(c => c.TypeCard).HasDefaultValue("Card Yellow");
            builder.Property(c => c.Time).IsRequired();
            builder.Property(c => c.Status).HasDefaultValue("valid");

            //KHoa ngoai giua card va period
            builder.HasOne(c => c.Period)
                .WithMany(p => p.Cards)
                .HasForeignKey(c => c.PeriodId);

        }
    }
}
