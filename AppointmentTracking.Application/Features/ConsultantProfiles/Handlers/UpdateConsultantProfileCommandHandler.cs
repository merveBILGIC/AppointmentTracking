using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.ConsultantProfiles.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.ConsultantProfiles.Handlers
{
    public class UpdateConsultantProfileCommandHandler
    : IRequestHandler<UpdateConsultantProfileCommand, Result<ConsultantProfileDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateConsultantProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
           _unitOfWork = unitOfWork;
           _mapper = mapper;
        }

        public async Task<Result<ConsultantProfileDto>> Handle(UpdateConsultantProfileCommand request, CancellationToken cancellationToken)
        {
            var existing = await _unitOfWork.ConsultantProfiles.GetByIdAsync(request.Id, cancellationToken);
            if (existing is null)
                return Result<ConsultantProfileDto>.Fail("Profil bulunamadı.");

            existing.Email = request.Email ?? existing.Email;
            existing.Biography = request.Biography ?? existing.Biography;
            existing.PhoneNumber = request.PhoneNumber ?? existing.PhoneNumber;
            existing.Address = request.Address ?? existing.Address;
            existing.ProfilePhotoUrl = request.ProfilePhotoUrl ?? existing.ProfilePhotoUrl;

            await _unitOfWork.ConsultantProfiles.UpdateAsync(existing, cancellationToken);

            var dto = _mapper.Map<ConsultantProfileDto>(existing);
            return Result<ConsultantProfileDto>.Ok(dto, "Profil güncellendi.");
        }
    }
}
