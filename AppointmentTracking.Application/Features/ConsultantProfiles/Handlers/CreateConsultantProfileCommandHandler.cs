using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.ConsultantProfiles.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Domain.Entities;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;

namespace AppointmentTracking.Application.Features.ConsultantProfiles.Handlers
{
    public class CreateConsultantProfileCommandHandler : IRequestHandler<CreateConsultantProfileCommand, Result<ConsultantProfileDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateConsultantProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<ConsultantProfileDto>> Handle(CreateConsultantProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = new ConsultantProfile
            {
                ConsultantId = request.ConsultantId,
                Email = request.Email,
                Biography = request.Biography,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                ProfilePhotoUrl = request.ProfilePhotoUrl
            };

            await _unitOfWork.ConsultantProfiles.AddAsync(profile);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<ConsultantProfileDto>(profile);
            return Result<ConsultantProfileDto>.Ok(dto, "Profil başarıyla oluşturuldu.");
        }
    }
}
