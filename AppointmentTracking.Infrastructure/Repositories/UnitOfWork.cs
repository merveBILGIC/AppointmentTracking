using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Infrastructure.Persistence.Context;

namespace AppointmentTracking.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context,
                      IAppointmentRepository appointmentRepository,
                      IConsultantRepository consultantRepository,
                      IConsultantProfileRepository consultantProfileRepository,
                      IClientRepository clientRepository,
                      IServiceRepository serviceRepository,
                      IConsultantServiceRepository consultantService,
                      ICategoryRepository categoriesRepository)
    {
        _context = context;
        Appointments = appointmentRepository;
        Consultants = consultantRepository;
        ConsultantProfiles = consultantProfileRepository;
        Clients = clientRepository;
        Services = serviceRepository;
        ConsultantService = consultantService;
        Categories = categoriesRepository;
    }
    public IConsultantServiceRepository ConsultantService{ get; }
    public IAppointmentRepository Appointments { get; }
    public IConsultantRepository Consultants { get; }
    public IConsultantProfileRepository ConsultantProfiles { get; }
    public IClientRepository Clients { get; }
    public IServiceRepository Services { get; }
    public ICategoryRepository Categories { get; }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
