using AppointmentTracking.Domain.Entities;

namespace AppointmentTracking.Application.Interfaces;

public interface IAppointmentRepository
{
    Task<Appointment?> GetByIdAsync(Guid id);
    Task<Appointment?> GetByIdWithIncludesAsync(Guid id);
    Task<List<Appointment>> GetAllWithIncludesAsync();
    Task AddAsync(Appointment appointment, CancellationToken cancellationToken);
    Task UpdateAsync(Appointment appointment);
}
