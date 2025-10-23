using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Consultant.Queries
{
    public record GetAllConsultantsQuery() : IRequest<Result<List<ConsultantDto>>>;
}
