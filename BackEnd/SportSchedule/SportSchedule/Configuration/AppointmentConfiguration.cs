using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportSchedule.Model;

namespace SportSchedule.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentModel>
    {
        public void Configure(EntityTypeBuilder<AppointmentModel> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(a => a.AppointmentId);
            builder.Property(a => a.Status).HasDefaultValue(false);
            builder.Property(a => a.DateSend).HasDefaultValue(DateTime.UtcNow);

            //Khoa ngoai voi bang user
            builder.HasOne(a => a.User)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.UserId);

            //Khoa ngoai voi bang match
            builder.HasOne(a => a.Match)
                .WithMany(m => m.Appointments)
                .HasForeignKey(a => a.MatchId);
        }
    }
}
