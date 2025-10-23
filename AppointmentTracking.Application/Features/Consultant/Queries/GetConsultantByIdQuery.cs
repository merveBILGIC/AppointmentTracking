using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Consultant.Queries;

public record GetConsultantByIdQuery(Guid Id) : IRequest<Result<ConsultantDto>>;
