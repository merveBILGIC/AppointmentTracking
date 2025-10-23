using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.ConsultantProfiles.Queries
{
    public record GetConsultantProfileByConsultantIdQuery(Guid ConsultantId)
    : IRequest<Result<ConsultantProfileDto>>;
}
