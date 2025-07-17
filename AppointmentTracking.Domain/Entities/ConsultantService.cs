using AppointmentTracking.SharedKernel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Domain.Entities
{
    public class ConsultantService : BaseEntity<Guid>
    {
        public Guid ConsultantId { get; set; }
        public Consultant Consultant { get; set; } = null!;

        public Guid ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
