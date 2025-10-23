using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.Client.Queries;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;

namespace AppointmentTracking.Application.Features.Client.Handlers;

public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, Result<IEnumerable<ClientDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllClientsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ClientDto>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        var clients = await _unitOfWork.Clients.GetAllAsync(cancellationToken);
        var dtos = _mapper.Map<IEnumerable<ClientDto>>(clients);
        return Result<IEnumerable<ClientDto>>.Ok(dtos);
    }
}
