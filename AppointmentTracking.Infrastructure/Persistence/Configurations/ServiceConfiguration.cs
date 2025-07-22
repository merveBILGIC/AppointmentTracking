using AppointmentTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AppointmentTracking.Infrastructure.Persistence.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Description)
                .HasMaxLength(1000); 

            builder.Property(s => s.Price)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(s => s.CategoryId)
                .IsRequired();

            builder.HasOne(s => s.Category)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); 

            //// ConsultantServices koleksiyonu için açık konfigürasyon gerekmez, ama olursa:
            //builder.HasMany(s => s.ConsultantServices)
            //    .WithOne(cs => cs.Service)
            //    .HasForeignKey(cs => cs.ServiceId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// İndeksler (performans için)
            //builder.HasIndex(s => s.Name);
            //builder.HasIndex(s => s.CategoryId);
        }
    }
}
