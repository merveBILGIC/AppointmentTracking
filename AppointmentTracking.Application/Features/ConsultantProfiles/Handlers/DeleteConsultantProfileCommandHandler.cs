using AppointmentTracking.Application.Features.ConsultantProfiles.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.ConsultantProfiles.Handlers
{
    public class DeleteConsultantProfileCommandHandler
    : IRequestHandler<DeleteConsultantProfileCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteConsultantProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteConsultantProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _unitOfWork.ConsultantProfiles.GetByIdAsync(request.Id, cancellationToken);
            if (profile is null)
                return Result<string>.Fail("Profil bulunamadı.");

            await _unitOfWork.ConsultantProfiles.DeleteAsync(profile, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<string>.Ok("Profil silindi.");
        }
    }
}
