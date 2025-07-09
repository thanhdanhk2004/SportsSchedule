using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<MemberModel>
    {
        public void Configure(EntityTypeBuilder<MemberModel> builder)
        {
            builder.ToTable("Member");
            builder.HasKey(m => m.MemberId);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Birthday).IsRequired();
            builder.Property(m => m.Nationality).IsRequired();
            builder.Property(m => m.Position).IsRequired();
            builder.Property(m => m.Age).IsRequired();
        }
    }
}
