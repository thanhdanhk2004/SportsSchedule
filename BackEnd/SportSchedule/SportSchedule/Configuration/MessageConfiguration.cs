using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<MessageModel>
    {
        public void Configure(EntityTypeBuilder<MessageModel> builder)
        {
            builder.ToTable("Message");
            builder.HasKey(m => m.MessageId);
            builder.Property(m => m.Content).IsRequired();
            builder.Property(m => m.Type).HasDefaultValue("string");
            builder.Property(m => m.Image).IsRequired();
            builder.Property(m => m.SendTime).HasDefaultValue(DateTime.Now);

            //khoa ngoai giua Message va UserSend
            builder.HasOne(m => m.UserSend)
                .WithMany(u => u.MessageSends)
                .HasForeignKey(m => m.UserIdSend);

            //khoa ngoai giua Message va UserRevice
            builder.HasOne(m => m.UserRevice)
                .WithMany(u => u.MessageRevices)
                .HasForeignKey(m => m.UserIdRevice);
        }
    }
}
