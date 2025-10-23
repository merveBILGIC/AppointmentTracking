using AppointmentTracking.Application.Features.Client.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Client.Handlers;

public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, Result<object>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClientHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<object>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(request.Id, cancellationToken);
        if (client is null) return Result<object>.Fail("Client not found");

        await _unitOfWork.Clients.DeleteAsync(client, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<object>.Ok(null);
    }
}
