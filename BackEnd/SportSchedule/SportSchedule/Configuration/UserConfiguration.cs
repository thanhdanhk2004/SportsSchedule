using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(30);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Role).HasDefaultValue(Role.Member);

            // Thiet lap khoa ngoai voi Tai khoan
            builder.HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<AccountModel>(a => a.UserId);

        }
    }
}
