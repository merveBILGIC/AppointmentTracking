using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Consultant.Commands
{
    public record UpdateConsultantCommand(Guid Id, string FullName, string Surname) : IRequest<Result<string>>;
}
