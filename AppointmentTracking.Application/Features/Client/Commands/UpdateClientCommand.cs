using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Client.Commands;

public record UpdateClientCommand(Guid Id, string FullName, string Email, string Phone) : IRequest<Result<object>>;
