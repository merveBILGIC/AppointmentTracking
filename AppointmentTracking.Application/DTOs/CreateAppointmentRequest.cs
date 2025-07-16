using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.DTOs
{
    public class CreateAppointmentRequest
    {
        public Guid ClientId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid ConsultantId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public string? Notes { get; set; }
    }
}
