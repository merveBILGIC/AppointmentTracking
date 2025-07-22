using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Client.Queries;

public record GetClientByIdQuery(Guid Id) : IRequest<Result<ClientDto>>;
