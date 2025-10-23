using AppointmentTracking.Application.Features.Catagories.Commands;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Catagories.Handlers;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Result<string>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(request.Id, cancellationToken);
        if (category is null)
            return Result<string>.Fail("Kategori bulunamadı");

        category.Name = request.Name;
        await _unitOfWork.Categories.UpdateAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Ok("Kategori güncellendi");
    }
}
