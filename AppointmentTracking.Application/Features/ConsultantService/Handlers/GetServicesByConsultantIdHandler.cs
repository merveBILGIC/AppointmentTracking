using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.ConsultantService.Queries;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;

namespace AppointmentTracking.Application.Features.ConsultantService.Handlers;

public class GetServicesByConsultantIdHandler : IRequestHandler<GetServicesByConsultantIdQuery, Result<IEnumerable<ServiceDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetServicesByConsultantIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ServiceDto>>> Handle(GetServicesByConsultantIdQuery request, CancellationToken cancellationToken)
    {
        var consultantServiceRepo = await _unitOfWork.ConsultantService.GetServicesByConsultantIdAsync(request.ConsultantId, cancellationToken);

        if (consultantServiceRepo is null)
         return Result<IEnumerable<ServiceDto>>.Fail("Danışmana ait servis bulunamadı.");
        

        var dtos = _mapper.Map<IEnumerable<ServiceDto>>(consultantServiceRepo);
        return Result<IEnumerable<ServiceDto>>.Ok(dtos);
    }
}
