using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.DTOs
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string ConsultantName { get; set; }
        public string ServiceName { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }
    }
}
