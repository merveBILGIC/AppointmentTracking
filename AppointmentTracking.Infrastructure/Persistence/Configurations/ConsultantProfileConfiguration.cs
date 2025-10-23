using AppointmentTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Infrastructure.Persistence.Configurations
{
    public class ConsultantProfileConfiguration : IEntityTypeConfiguration<ConsultantProfile>
    {
        public void Configure(EntityTypeBuilder<ConsultantProfile> builder)
        {
           
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Biography).HasMaxLength(1000);
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);
            builder.Property(p => p.Address).HasMaxLength(200);
            builder.Property(p => p.ProfilePhotoUrl).HasMaxLength(255);

            builder
                .HasOne(p => p.Consultant)
                .WithOne(c => c.ConsultantProfile)
                .HasForeignKey<ConsultantProfile>(p => p.ConsultantId);
        }
    }
}
