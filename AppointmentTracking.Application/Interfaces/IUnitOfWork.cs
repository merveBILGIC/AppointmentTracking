using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        IConsultantRepository Consultants { get; }
        IConsultantProfileRepository ConsultantProfiles { get; }
        IConsultantServiceRepository ConsultantService { get; }
        ICategoryRepository Categories { get; }
        IClientRepository Clients { get; }
        IServiceRepository Services { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
