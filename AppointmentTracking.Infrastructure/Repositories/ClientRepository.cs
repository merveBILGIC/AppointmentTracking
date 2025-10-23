using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Domain.Entities;
using AppointmentTracking.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppointmentTracking.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Clients.ToListAsync(cancellationToken);
    }

    public async Task<Client?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Clients.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task AddAsync(Client entity, CancellationToken cancellationToken = default)
    {
        await _context.Clients.AddAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(Client entity, CancellationToken cancellationToken = default)
    {
        _context.Clients.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Client entity, CancellationToken cancellationToken = default)
    {
        _context.Clients.Remove(entity);
        return Task.CompletedTask;
    }
}
