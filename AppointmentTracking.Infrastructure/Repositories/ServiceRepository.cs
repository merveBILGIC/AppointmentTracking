using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Domain.Entities;
using AppointmentTracking.Infrastructure.Persistence.Context;

namespace AppointmentTracking.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context)
        {
                _context = context;
        }
        public Task AddAsync(Service service, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Service>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Service?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Service service, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
