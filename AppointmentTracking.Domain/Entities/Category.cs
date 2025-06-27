using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentTracking.SharedKernel.Base;

namespace AppointmentTracking.Domain.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;

        public ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
