using AppointmentTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentTracking.Infrastructure.Persistence.Configurations;

public class ConsultantServiceConfiguration : IEntityTypeConfiguration<ConsultantService>
{
    public void Configure(EntityTypeBuilder<ConsultantService> builder)
    {
        builder.HasKey(cs => cs.Id);

        builder.HasIndex(cs => new { cs.ConsultantId, cs.ServiceId }).IsUnique();

        builder.HasOne(cs => cs.Consultant)
            .WithMany(c => c.ConsultantServices)
            .HasForeignKey(cs => cs.ConsultantId);

        builder.HasOne(cs => cs.Service)
            .WithMany(s => s.ConsultantServices)
            .HasForeignKey(cs => cs.ServiceId);
    }
}
