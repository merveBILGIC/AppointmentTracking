using AppointmentTracking.Domain.Entities;

namespace AppointmentTracking.Application.Interfaces;

public interface IConsultantRepository
{
    Task<Consultant?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Consultant>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Consultant consultant, CancellationToken cancellationToken = default);
    Task UpdateAsync(Consultant consultant, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}
