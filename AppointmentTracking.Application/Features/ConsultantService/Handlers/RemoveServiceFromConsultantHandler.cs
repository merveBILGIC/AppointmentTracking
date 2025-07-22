using AppointmentTracking.Application.Features.ConsultantService.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.ConsultantService.Handlers;

public class RemoveServiceFromConsultantHandler: IRequestHandler<RemoveServiceFromConsultantCommand, Result<string>>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveServiceFromConsultantHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> Handle(RemoveServiceFromConsultantCommand request, CancellationToken cancellationToken)
    {
       
        var existing = await _unitOfWork.ConsultantService.GetConsultantsByServiceIdAsync(
            request.ConsultantId, request.ServiceId, cancellationToken);

        if (existing is null)
        {
            return Result<string>.Fail("Bu danışmana ait böyle bir hizmet bulunamadı.");
        }

        await _unitOfWork.ConsultantService.DeleteAsync(request.ConsultantId, request.ServiceId, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Ok("Hizmet danışmandan başarıyla kaldırıldı.");
    }
}
