using AppointmentTracking.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.Client.Commands
{
    public record DeleteClientCommand(Guid Id) : IRequest<Result<object>>;
}
