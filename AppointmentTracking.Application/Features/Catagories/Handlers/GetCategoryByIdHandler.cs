using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.Catagories.Queries;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;

namespace AppointmentTracking.Application.Features.Catagories.Handlers;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(request.Id, cancellationToken);
        if (category is null)
            return Result<CategoryDto>.Fail("Kategori bulunamadı");

        var dto = _mapper.Map<CategoryDto>(category);
        return Result<CategoryDto>.Ok(dto);
    }
}
