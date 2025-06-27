using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentTracking.SharedKernel.Base;

namespace AppointmentTracking.Domain.Entities
{
    public class Appointment : BaseEntity<Guid>
    {
        public Guid ConsultantId { get; set; }
        public Consultant Consultant { get; set; } = null!;

        public Guid ClientId { get; set; }
        public Client Client { get; set; } = null!;

        public Guid ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsPaid { get; set; } = false;
    }
}
