using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Domain.Entities;
using AppointmentTracking.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentTracking.Infrastructure.Repositories;

public class ConsultantServiceRepository : IConsultantServiceRepository
{
    private readonly ApplicationDbContext _context;

    public ConsultantServiceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ConsultantService entity, CancellationToken cancellationToken = default)
    {
        await _context.ConsultantServices.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid consultantId, Guid serviceId, CancellationToken cancellationToken = default)
    {
        var entry = await _context.ConsultantServices.FirstOrDefaultAsync(
            x => x.ConsultantId == consultantId && x.ServiceId == serviceId, cancellationToken);

        if (entry != null)
        {
            _context.ConsultantServices.Remove(entry);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<IEnumerable<Service>> GetServicesByConsultantIdAsync(Guid consultantId, Guid serviceId, CancellationToken cancellationToken = default)
    {
        return await _context.ConsultantServices
            .Where(cs => cs.ConsultantId == consultantId && cs.ServiceId == serviceId)
            .Select(cs => cs.Service)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Consultant>> GetConsultantsByServiceIdAsync(Guid consultantId,Guid serviceId, CancellationToken cancellationToken = default)
    {
        return await _context.ConsultantServices
            .Where(cs => cs.ServiceId == serviceId && cs.ConsultantId == consultantId)
            .Select(cs => cs.Consultant)
            .ToListAsync(cancellationToken);
    }
}
