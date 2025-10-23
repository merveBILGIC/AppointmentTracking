using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.Appointment.Queries;
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
    public class GetAppointmentsHandler : IRequestHandler<GetAppointmentsQuery, Result<List<AppointmentDto>>>
    {
        private readonly IAppointmentRepository _repo;

        public GetAppointmentsHandler(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<List<AppointmentDto>>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _repo.GetAllWithIncludesAsync();
            var dtos = appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                ClientName = a.Client.FullName,
                ConsultantName = a.Consultant.Name,
                ServiceName = a.Service.Title,
                StartTime = a.StartTime,
                Price = a.Price
            }).ToList();

            return Result<List<AppointmentDto>>.Ok(dtos);
        }
    }
}
