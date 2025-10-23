using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.ConsultantService.Queries;

public record GetServicesByConsultantIdQuery(Guid ConsultantId , Guid ServiceId) : IRequest<Result<IEnumerable<ServiceDto>>>;
