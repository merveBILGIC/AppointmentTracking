using AppointmentTracking.Application.Features.Appointment.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Appointment.Handlers
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAppointmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new AppointmentTracking.Domain.Entities.Appointment
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

            await _unitOfWork.Appointments.AddAsync(appointment, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Ok(appointment.Id, "Randevu oluşturuldu.");
        }
    }

}
