using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMemberModel>
    {
        public void Configure(EntityTypeBuilder<TeamMemberModel> builder)
        {
            builder.ToTable("TeamMember");
            builder.HasKey(tm => new {tm.MemberId, tm.TeamId});

            //Thiet lap khoa ngoai voi hai bang Team va Member
            builder.HasOne(tm => tm.Team)
                .WithMany(t => t.TeamMembers)
                .HasForeignKey(tm => tm.TeamId);

            builder.HasOne(tm => tm.Member)
                .WithMany(m => m.TeamMembers)
                .HasForeignKey(tm => tm.MemberId);
        }
    }
}
