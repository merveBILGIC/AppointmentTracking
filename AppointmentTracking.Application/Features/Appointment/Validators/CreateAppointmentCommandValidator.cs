using AppointmentTracking.Application.Features.Appointment.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.Appointment.Validators
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(x => x.ClientId).NotEmpty().WithMessage("ClientId boş olamaz.");
            RuleFor(x => x.ConsultantId).NotEmpty().WithMessage("ConsultantId boş olamaz.");
            RuleFor(x => x.ServiceId).NotEmpty().WithMessage("ServiceId boş olamaz.");
            RuleFor(x => x.StartTime).LessThan(x => x.EndTime).WithMessage("Başlangıç zamanı, bitiş zamanından küçük olmalı.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalı.");
        }
    }
}
