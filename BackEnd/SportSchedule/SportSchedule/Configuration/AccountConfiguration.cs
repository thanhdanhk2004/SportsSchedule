using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountModel>
    {
        public void Configure(EntityTypeBuilder<AccountModel> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(a => a.AccountId);
            builder.Property(a => a.UserName).IsRequired();
            builder.HasIndex(a => a.UserName).IsUnique();
            builder.Property(a => a.Password).IsRequired();
        }
    }
}
