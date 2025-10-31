using AppointmentTracking.Application.Features.Consultant.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Consultant.Handlers
{
    public class UpdateConsultantHandler : IRequestHandler<UpdateConsultantCommand, Result<string>>
    {
        private readonly IUnitOfWork _uow;

        public UpdateConsultantHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Result<string>> Handle(UpdateConsultantCommand request, CancellationToken cancellationToken)
        {
            var consultant = await _uow.Consultants.GetByIdAsync(request.Id, cancellationToken);
            if (consultant is null)
                return Result<string>.Fail("Danışman bulunamadı.");

            consultant.FullName = request.FullName;
            consultant.Surname = request.Surname;

            await _uow.Consultants.UpdateAsync(consultant, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Result<string>.Ok("Danışman güncellendi.");
        }
    }
}
