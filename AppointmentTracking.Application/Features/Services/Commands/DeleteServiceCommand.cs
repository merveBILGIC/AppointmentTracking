using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Services.Commands
{
    public class DeleteServiceCommand : IRequest<Result<string>>
    {
        public Guid Id { get; set; }
    }
}
