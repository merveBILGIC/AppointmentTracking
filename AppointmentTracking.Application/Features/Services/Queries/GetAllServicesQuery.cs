using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Services.Queries
{
    public class GetAllServicesQuery : IRequest<Result<List<ServiceDto>>>
    {
    }
}
