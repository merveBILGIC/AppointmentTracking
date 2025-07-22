using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.Consultant.Queries;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;

namespace AppointmentTracking.Application.Features.Consultant.Handlers;

public class GetConsultantByIdHandler : IRequestHandler<GetConsultantByIdQuery, Result<ConsultantDto>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetConsultantByIdHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Result<ConsultantDto>> Handle(GetConsultantByIdQuery request, CancellationToken cancellationToken)
    {
        var consultant = await _uow.Consultants.GetByIdAsync(request.Id, cancellationToken);
        if (consultant is null)
            return Result<ConsultantDto>.Fail("Danışman bulunamadı.");

        var dto = _mapper.Map<ConsultantDto>(consultant);
        return Result<ConsultantDto>.Ok(dto);
    }
}
