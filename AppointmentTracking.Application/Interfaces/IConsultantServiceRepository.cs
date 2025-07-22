using AppointmentTracking.Domain.Entities;

namespace AppointmentTracking.Application.Interfaces;

public interface IConsultantServiceRepository
{
    Task AddAsync(ConsultantService entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid consultantId, Guid serviceId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Service>> GetServicesByConsultantIdAsync(Guid consultantId, Guid serviceId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Consultant>> GetConsultantsByServiceIdAsync(Guid consultantId, Guid serviceId, CancellationToken cancellationToken = default);
}

