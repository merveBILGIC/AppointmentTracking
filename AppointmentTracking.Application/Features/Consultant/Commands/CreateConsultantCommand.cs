using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Consultant.Commands
{
    public record CreateConsultantCommand(string Name, string Surname) : IRequest<Result<Guid>>;

}
