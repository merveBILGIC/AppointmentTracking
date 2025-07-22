using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Consultant.Commands
{
    public record DeleteConsultantCommand(Guid Id) : IRequest<Result<string>>;
}
