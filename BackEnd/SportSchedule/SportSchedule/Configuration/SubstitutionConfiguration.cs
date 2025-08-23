using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class SubstitutionConfiguration : IEntityTypeConfiguration<SubstitutionModel>
    {
        public void Configure(EntityTypeBuilder<SubstitutionModel> builder)
        {
            builder.ToTable("Substitution");
            builder.HasKey(s => s.SubId);
            builder.Property(s => s.Time).IsRequired();

            //KHoa ngoai voi Match
            builder.HasOne(s => s.Match)
                .WithMany(m => m.Substitutions)
                .HasForeignKey(s => s.MatchId);

            //Khoa ngoai voi PlayerIn va PlayerOut
            builder.HasOne(s => s.PlayerIn)
                .WithMany(p => p.SubstitutionIn)
                .HasForeignKey(s => s.PlayerInId);

            builder.HasOne(s => s.PlayerOut)
               .WithMany(p => p.SubstitutionOut)
               .HasForeignKey(s => s.PlayerOutId);
        }
    }
}
