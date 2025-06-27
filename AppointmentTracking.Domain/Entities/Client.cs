using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentTracking.SharedKernel.Base;

namespace AppointmentTracking.Domain.Entities
{
    public class Client : BaseEntity<Guid>
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        // İlişkiler
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
