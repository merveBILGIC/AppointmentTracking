using AppointmentTracking.Application.Features.Appointment.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AppointmentTracking.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.Appointment.Handlers
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, Result<Guid>>
    {
        private readonly IAppointmentRepository _repo;

        public CreateAppointmentHandler(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<Guid>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                ClientId = request.ClientId,
                ConsultantId = request.ConsultantId,
                ServiceId = request.ServiceId,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Price = request.Price,
                Notes = request.Notes,
                IsPaid = false,
                IsDeleted = false
            };
            //TODO: dönüş tipi olarak guid yerine veriye de gönderebiliriz. oluşan randevunun takvime eklenmesi gibi gibi...
            await _repo.AddAsync(appointment);
            return Result<Guid>.Ok(appointment.Id, "Randevu oluşturuldu.");
        }
    }
}
