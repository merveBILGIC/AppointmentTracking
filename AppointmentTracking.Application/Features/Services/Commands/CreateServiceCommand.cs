using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Services.Commands
{

    public class CreateServiceCommand : IRequest<Result<ServiceDto>>
    {
            public string Name { get; set; } = default!;
            public string Description { get; set; } = default!;
            public decimal Price { get; set; }
    }
    
}
