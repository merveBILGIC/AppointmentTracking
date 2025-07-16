using AppointmentTracking.Application.Features.Appointment.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.Appointment.Handlers
{
    public class DeleteAppointmentHandler : IRequestHandler<DeleteAppointmentCommand, Result<Guid>>
    {
        private readonly IAppointmentRepository _repo;

        public DeleteAppointmentHandler(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<Guid>> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _repo.GetByIdAsync(request.Id);
            if (appointment == null)
                return Result<Guid>.Fail("Randevu bulunamadı.");

            //TODO: congigurasyon kısmında best practice nedir diye bak.
            appointment.IsDeleted = true;
            await _repo.UpdateAsync(appointment);

            return Result<Guid>.Ok(appointment.Id, "Randevu silindi.");
        }
    }
}
