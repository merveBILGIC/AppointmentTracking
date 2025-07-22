using AppointmentTracking.Application.Features.Appointment.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Appointment.Handlers
{
    public class UpdateAppointmentHandler : IRequestHandler<UpdateAppointmentCommand, Result<Guid>>
    {
        private readonly IAppointmentRepository _repo;

        public UpdateAppointmentHandler(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<Guid>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _repo.GetByIdAsync(request.Id);
            if (appointment == null)
                return Result<Guid>.Fail("Randevu bulunamadı.");

            appointment.StartTime = request.StartTime;
            appointment.EndTime = request.EndTime;
            appointment.Price = request.Price;
            appointment.Notes = request.Notes;
            appointment.UpdatedAt = DateTime.UtcNow;

            await _repo.UpdateAsync(appointment);
            return Result<Guid>.Ok(appointment.Id, "Randevu güncellendi.");
        }
    }
}
