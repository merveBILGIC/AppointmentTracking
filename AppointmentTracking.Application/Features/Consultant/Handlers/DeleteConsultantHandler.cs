using AppointmentTracking.Application.Features.Consultant.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Consultant.Handlers
{
    public class DeleteConsultantHandler : IRequestHandler<DeleteConsultantCommand, Result<string>>
    {
        private readonly IUnitOfWork _uow;

        public DeleteConsultantHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Result<string>> Handle(DeleteConsultantCommand request, CancellationToken cancellationToken)
        {
            await _uow.Consultants.DeleteAsync(request.Id, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Result<string>.Ok("Danışman silindi.");
        }
    }
}
