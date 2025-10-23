using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Domain.Entities;
using AppointmentTracking.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentTracking.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Service service, CancellationToken cancellationToken = default)
        {
            await _context.Services.AddAsync(service, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var service = await _context.Services.FindAsync(new object[] { id }, cancellationToken);
            if (service is not null)
            {
                _context.Services.Remove(service);
            }
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Services.AnyAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Service service, CancellationToken cancellationToken = default)
        {
            _context.Services.Update(service);
        }
    }

}
