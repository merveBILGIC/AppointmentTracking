using AppointmentTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment?> GetByIdAsync(Guid id);
        Task<Appointment?> GetByIdWithIncludesAsync(Guid id);
        Task<List<Appointment>> GetAllWithIncludesAsync();
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task<IEnumerable<object>> GetAllAsync();
    }
}
