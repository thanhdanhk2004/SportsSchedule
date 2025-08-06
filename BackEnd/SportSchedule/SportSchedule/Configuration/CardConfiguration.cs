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

            //KHoa ngoai giua card va match
            builder.HasOne(c => c.Match)
                .WithMany(m => m.Cards)
                .HasForeignKey(c => c.MatchId);

            //Khoa ngoai giua card va member
            builder.HasOne(c => c.Member)
                .WithMany(m => m.Cards)
                .HasForeignKey(c => c.MemberId);
        }
    }
}
