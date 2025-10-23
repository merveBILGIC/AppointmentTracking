using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.ConsultantProfiles.Queries
{
    public record GetAllConsultantProfilesQuery : IRequest<Result<List<ConsultantProfileDto>>>;
}
