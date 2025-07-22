using AppointmentTracking.Domain.Entities;

namespace AppointmentTracking.Application.Interfaces;

public interface IClientRepository 
{
    Task<IEnumerable<Client>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Client?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Client entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Client entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Client entity, CancellationToken cancellationToken = default);
}
