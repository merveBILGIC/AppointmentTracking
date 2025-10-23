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
    public class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentByIdQuery, Result<AppointmentDto>>
    {
        private readonly IAppointmentRepository _repo;

        public GetAppointmentByIdHandler(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<AppointmentDto>> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var a = await _repo.GetByIdWithIncludesAsync(request.Id);
            if (a == null)
                return Result<AppointmentDto>.Fail("Randevu bulunamadı.");

            var dto = new AppointmentDto
            {
                Id = a.Id,
                ClientName = a.Client.FullName,
                ConsultantName = a.Consultant.Name,
                ServiceName = a.Service.Title,
                StartTime = a.StartTime,
                Price = a.Price
            };

            return Result<AppointmentDto>.Ok(dto);
        }
    }
}
