using AppointmentTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Interfaces
{
    public interface IConsultantProfileRepository
    {
        Task<ConsultantProfile?> GetByConsultantIdAsync(Guid consultantId, CancellationToken cancellationToken = default);
        Task<ConsultantProfile?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<ConsultantProfile>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(ConsultantProfile profile, CancellationToken cancellationToken = default);
        Task UpdateAsync(ConsultantProfile profile, CancellationToken cancellationToken = default);
        Task DeleteAsync(ConsultantProfile profile, CancellationToken cancellationToken = default);
    }
}
