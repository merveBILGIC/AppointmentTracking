using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.ConsultantService.Commands;

public record AssignServiceToConsultantCommand(Guid ConsultantId, Guid ServiceId) : IRequest<Result<string>>;
