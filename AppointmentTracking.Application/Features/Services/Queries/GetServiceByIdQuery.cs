using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Services.Queries
{
    public class GetServiceByIdQuery : IRequest<Result<ServiceDto>>
    {
        public Guid Id { get; set; }
    }
}
