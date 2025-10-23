using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Domain.Entities;
using AppointmentTracking.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentTracking.Infrastructure.Repositories;

public class ConsultantRepository : IConsultantRepository
{
    private readonly ApplicationDbContext _context;

    public ConsultantRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Consultant?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Consultants
            .Include(c => c.ConsultantProfile)
            .Include(c => c.Appointments)
            .Include(c => c.ConsultantServices)
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted, cancellationToken);
    }

    public async Task<List<Consultant>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Consultants
            .Where(c => !c.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Consultant consultant, CancellationToken cancellationToken = default)
    {
        await _context.Consultants.AddAsync(consultant, cancellationToken);
    }

    public Task UpdateAsync(Consultant consultant, CancellationToken cancellationToken = default)
    {
        _context.Consultants.Update(consultant);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var consultant = await GetByIdAsync(id, cancellationToken);
        if (consultant != null)
        {
            consultant.IsDeleted = true;
        }
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Consultants.AnyAsync(c => c.Id == id && !c.IsDeleted, cancellationToken);
    }
}
