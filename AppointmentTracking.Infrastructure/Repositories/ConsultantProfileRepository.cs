using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Domain.Entities;
using AppointmentTracking.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentTracking.Infrastructure.Repositories
{
    public class ConsultantProfileRepository : IConsultantProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public ConsultantProfileRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<ConsultantProfile?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.ConsultantProfiles
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }
        public async Task<ConsultantProfile?> GetByConsultantIdAsync(Guid consultantId, CancellationToken cancellationToken = default)
        {
            return await _context.ConsultantProfiles
                .FirstOrDefaultAsync(p => p.ConsultantId == consultantId, cancellationToken);
        }
        public async Task<List<ConsultantProfile>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ConsultantProfiles.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(ConsultantProfile profile, CancellationToken cancellationToken = default)
        {
            await _context.ConsultantProfiles.AddAsync(profile, cancellationToken);
        }
        public Task UpdateAsync(ConsultantProfile profile, CancellationToken cancellationToken = default)
        {
            _context.ConsultantProfiles.Update(profile);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(ConsultantProfile profile, CancellationToken cancellationToken = default)
        {
            _context.ConsultantProfiles.Remove(profile);
            return Task.CompletedTask;
        }
    }
}
