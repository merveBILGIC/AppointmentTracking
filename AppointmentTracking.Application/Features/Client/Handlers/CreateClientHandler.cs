using AppointmentTracking.Application.Features.Client.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;

namespace AppointmentTracking.Application.Features.Client.Handlers;

public class CreateClientHandler : IRequestHandler<CreateClientCommand, Result<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateClientHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = new AppointmentTracking.Domain.Entities.Client
        {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            Email = request.Email,
            Phone = request.Phone
        };

        await _unitOfWork.Clients.AddAsync(client, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Ok(client.Id);
    }
}
