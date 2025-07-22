using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.Client.Queries;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;

namespace AppointmentTracking.Application.Features.Client.Handlers;

public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Result<ClientDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetClientByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ClientDto>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(request.Id, cancellationToken);
        if (client is null) return Result<ClientDto>.Fail("Client not found");

        var dto = _mapper.Map<ClientDto>(client);
        return Result<ClientDto>.Ok(dto);
    }
}
