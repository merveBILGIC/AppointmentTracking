using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.ConsultantProfiles.Commands
{
    public class CreateConsultantProfileCommand : IRequest<Result<ConsultantProfileDto>>
    {
        public Guid ConsultantId { get; set; }
        public string Email { get; set; } = null!;
        public string Biography { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ProfilePhotoUrl { get; set; }
    }
}
