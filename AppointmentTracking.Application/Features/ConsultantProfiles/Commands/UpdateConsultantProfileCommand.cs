using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.ConsultantProfiles.Commands
{
    public class UpdateConsultantProfileCommand : IRequest<Result<ConsultantProfileDto>>
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Biography { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ProfilePhotoUrl { get; set; }
    }
}
