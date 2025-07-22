using AppointmentTracking.Application.Features.ConsultantService.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.ConsultantService.Handlers;

public class AssignServiceToConsultantHandler : IRequestHandler<AssignServiceToConsultantCommand, Result<string>>
{
    private readonly IConsultantServiceRepository _repo;

    public AssignServiceToConsultantHandler(IConsultantServiceRepository repo)
    {
        _repo = repo;
    }

    public async Task<Result<string>> Handle(AssignServiceToConsultantCommand request, CancellationToken cancellationToken)
    {
        var relation = new AppointmentTracking.Domain.Entities.ConsultantService
        {
            Id = Guid.NewGuid(),
            ConsultantId = request.ConsultantId,
            ServiceId = request.ServiceId
        };

        await _repo.AddAsync(relation, cancellationToken);
        return Result<string>.Ok("Hizmet danışmana atandı.");
    }
}
