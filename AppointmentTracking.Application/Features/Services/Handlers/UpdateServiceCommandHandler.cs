using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.Services.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;

namespace AppointmentTracking.Application.Features.Services.Handlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Result<ServiceDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateServiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ServiceDto>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(request.Id, cancellationToken);
            if (service is null)
                return Result<ServiceDto>.Fail("Hizmet bulunamadı.");

            service.Name = request.Name;
            service.Description = request.Description;
            service.Price = request.Price;

            await _unitOfWork.Services.UpdateAsync(service, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<ServiceDto>(service);
            return Result<ServiceDto>.Ok(dto, "Hizmet güncellendi.");
        }
    }
}
