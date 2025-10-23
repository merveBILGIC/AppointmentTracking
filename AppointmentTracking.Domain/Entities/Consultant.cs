using AppointmentTracking.SharedKernel.Base;

namespace AppointmentTracking.Domain.Entities
{
    public class Consultant : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        
        // İlişkiler
        public ConsultantProfile? ConsultantProfile { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<ConsultantService> ConsultantServices { get; set; } = new List<ConsultantService>();
    }
}
