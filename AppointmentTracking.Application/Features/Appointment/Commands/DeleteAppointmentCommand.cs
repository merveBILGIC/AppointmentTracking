using AppointmentTracking.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.Appointment.Commands
{
    public class DeleteAppointmentCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
    }
}
