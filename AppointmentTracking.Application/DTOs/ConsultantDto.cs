namespace AppointmentTracking.Application.DTOs
{
    public class ConsultantDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Surname { get; set; } = null!;
    }
}
