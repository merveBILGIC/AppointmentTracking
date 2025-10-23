using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.Consultant.Queries;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;

namespace AppointmentTracking.Application.Features.Consultant.Handlers;

public class GetAllConsultantsHandler : IRequestHandler<GetAllConsultantsQuery, Result<List<ConsultantDto>>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllConsultantsHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Result<List<ConsultantDto>>> Handle(GetAllConsultantsQuery request, CancellationToken cancellationToken)
    {
        var consultants = await _uow.Consultants.GetAllAsync(cancellationToken);
        var dtoList = _mapper.Map<List<ConsultantDto>>(consultants);
        return Result<List<ConsultantDto>>.Ok(dtoList);
    }
}
