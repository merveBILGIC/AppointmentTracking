using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Client.Commands;

public record CreateClientCommand(string FullName, string Email, string Phone) : IRequest<Result<Guid>>;
