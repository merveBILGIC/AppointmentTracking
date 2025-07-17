using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.DTOs
{
    public class ConsultantProfileDto
    {
        public Guid Id { get; set; }
        public Guid ConsultantId { get; set; }
        public string Email { get; set; } = null!;
        public string Biography { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ProfilePhotoUrl { get; set; }
    }
}
