using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Consultant.Commands
{
    public record UpdateConsultantCommand(Guid Id, string Name, string Surname) : IRequest<Result<string>>;
}
