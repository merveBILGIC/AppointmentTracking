using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Domain.Entities;
using AppointmentTracking.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentTracking.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<Category>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<Category>().ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Category category, CancellationToken cancellationToken)
    {
        await _context.Set<Category>().AddAsync(category, cancellationToken);
    }

    public Task UpdateAsync(Category category, CancellationToken cancellationToken)
    {
        _context.Set<Category>().Update(category);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Category category, CancellationToken cancellationToken)
    {
        _context.Set<Category>().Remove(category);
        return Task.CompletedTask;
    }
}
