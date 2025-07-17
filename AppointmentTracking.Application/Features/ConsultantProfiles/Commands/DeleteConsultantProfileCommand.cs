using AppointmentTracking.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.ConsultantProfiles.Commands
{
    public record DeleteConsultantProfileCommand(Guid Id) : IRequest<Result<string>>;
}
