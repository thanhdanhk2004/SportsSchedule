using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<PostModel>
    {
        public void Configure(EntityTypeBuilder<PostModel> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(p => p.PostId);
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.Image).IsRequired(false);
            builder.Property(p => p.Created).HasDefaultValue(DateTime.UtcNow);

            //Thiet lap khoa ngoai giua bang User va bang Post
            builder.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);

            

        }
    }
}
