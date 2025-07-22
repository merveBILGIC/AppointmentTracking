using AppointmentTracking.Application.Features.Consultant.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Consultant.Handlers
{
    public class CreateConsultantHandler : IRequestHandler<CreateConsultantCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _uow;

        public CreateConsultantHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Result<Guid>> Handle(CreateConsultantCommand request, CancellationToken cancellationToken)
        {
            var consultant = new AppointmentTracking.Domain.Entities.Consultant
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname
            };

            await _uow.Consultants.AddAsync(consultant, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Ok(consultant.Id, "Danışman oluşturuldu.");
        }
    }
}
