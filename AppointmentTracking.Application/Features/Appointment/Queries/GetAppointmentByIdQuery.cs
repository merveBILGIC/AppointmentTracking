using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.Appointment.Queries
{
    public class GetAppointmentByIdQuery : IRequest<Result<AppointmentDto>>
    {
        public Guid Id { get; set; }
    }
}
