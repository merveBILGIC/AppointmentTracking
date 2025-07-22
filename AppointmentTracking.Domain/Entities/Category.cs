using AppointmentTracking.SharedKernel.Base;

namespace AppointmentTracking.Domain.Entities;

public class Category : BaseEntity<Guid>
{
    public string Name { get; set; } = null!;

    public ICollection<Service> Services { get; set; } = new List<Service>();
}
