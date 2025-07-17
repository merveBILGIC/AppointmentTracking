using AppointmentTracking.SharedKernel.Base;

namespace AppointmentTracking.Domain.Entities
{
    public class Service : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<ConsultantService> ConsultantServices { get; set; } = new List<ConsultantService>();
    }
}
