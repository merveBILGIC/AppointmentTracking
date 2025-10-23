using AppointmentTracking.Application.Features.Services.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Services.Handlers
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.Services.ExistsAsync(request.Id, cancellationToken);
            if (!exists)
                return Result<string>.Fail("Silinecek hizmet bulunamadı.");

            await _unitOfWork.Services.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<string>.Ok("Hizmet başarıyla silindi.");
        }
    }
}
