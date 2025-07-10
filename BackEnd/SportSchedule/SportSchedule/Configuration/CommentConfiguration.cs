using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<CommentModel>
    {
        public void Configure(EntityTypeBuilder<CommentModel> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(c => c.CommentId);
            builder.Property(c => c.Content).IsRequired();
            builder.Property(c => c.Created).HasDefaultValue(DateTime.UtcNow);
            builder.Property(c => c.CommendIdReply).IsRequired(false);

            //Khoa ngoai bang Post va bang Comment
            builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            //Khoa ngoai bang User va Comment
            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            // Thiet lap khoa ngoai khi phan hoi Comment
            builder.HasOne(c => c.Comment)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.CommendIdReply)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
