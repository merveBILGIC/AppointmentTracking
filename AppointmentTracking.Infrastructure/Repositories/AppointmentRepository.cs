using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Domain.Entities;
using AppointmentTracking.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentTracking.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment?> GetByIdAsync(Guid id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }

        public async Task<Appointment?> GetByIdWithIncludesAsync(Guid id)
        {
            return await _context.Appointments
                .Include(a => a.Client)
                .Include(a => a.Consultant)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }

        public async Task<List<Appointment>> GetAllWithIncludesAsync()
        {
            return await _context.Appointments
                .Include(a => a.Client)
                .Include(a => a.Consultant)
                .Include(a => a.Service)
                .Where(a => !a.IsDeleted)
                .ToListAsync();
        }

        public async Task AddAsync(Appointment appointment , CancellationToken cancellationToken)
        {
            await _context.Appointments.AddAsync(appointment,cancellationToken);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
