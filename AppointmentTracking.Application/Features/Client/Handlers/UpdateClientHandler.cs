using AppointmentTracking.Application.Features.Client.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Client.Handlers;

public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, Result<object>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClientHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<object>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(request.Id, cancellationToken);
        if (client is null) return Result<object>.Fail("Client not found");

        client.FullName = request.FullName;
        client.Email = request.Email;
        client.Phone = request.Phone;

        await _unitOfWork.Clients.UpdateAsync(client, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<object>.Ok(null);
    }
}
