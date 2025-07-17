using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context,
                          IAppointmentRepository appointmentRepository,
                          //IConsultantRepository consultantRepository,
                          IConsultantProfileRepository consultantProfileRepository)
                          //IClientRepository clientRepository,
                          //IServiceRepository serviceRepository)
        {
            _context = context;
            Appointments = appointmentRepository;
            //Consultants = consultantRepository;
            ConsultantProfiles = consultantProfileRepository;
            //Clients = clientRepository;
            //Services = serviceRepository;
        }

        public IAppointmentRepository Appointments { get; }
        //public IConsultantRepository Consultants { get; }
        public IConsultantProfileRepository ConsultantProfiles { get; }
        //public IClientRepository Clients { get; }
        //public IServiceRepository Services { get; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
