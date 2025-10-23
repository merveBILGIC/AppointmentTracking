using AppointmentTracking.SharedKernel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Domain.Entities
{
    public class ConsultantProfile : BaseEntity<Guid>
    {
        public Guid ConsultantId { get; set; }
        public Consultant Consultant { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Biography { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ProfilePhotoUrl { get; set; }
    }
}
