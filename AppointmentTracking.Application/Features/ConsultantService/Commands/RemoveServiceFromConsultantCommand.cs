using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.ConsultantService.Commands;

public record RemoveServiceFromConsultantCommand(Guid ConsultantId, Guid ServiceId) : IRequest<Result<string>>;