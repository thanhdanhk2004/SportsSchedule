using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.User)
                .WithOne(u => u.Role)
                .HasForeignKey<UserModel>(u => u.RoleId);
        }
    }
}
