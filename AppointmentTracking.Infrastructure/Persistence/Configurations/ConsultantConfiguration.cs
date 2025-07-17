using AppointmentTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppointmentTracking.Infrastructure.Persistence.Configurations;

    public class ConsultantConfiguration : IEntityTypeConfiguration<Consultant>
    {
        public void Configure(EntityTypeBuilder<Consultant> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Surname).IsRequired().HasMaxLength(50);
      

            builder.HasOne(c => c.ConsultantProfile)
              .WithOne(p => p.Consultant)
              .HasForeignKey<ConsultantProfile>(p => p.ConsultantId)
              .OnDelete(DeleteBehavior.Cascade);
    }
    }

