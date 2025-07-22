namespace AppointmentTracking.Application.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Domain.Entities.Service>> GetAllAsync();
        Task<Domain.Entities.Service?> GetByIdAsync(Guid id,CancellationToken cancellationToken=default);
        Task AddAsync(Domain.Entities.Service service, CancellationToken cancellationToken = default);
        Task UpdateAsync(Domain.Entities.Service service, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
