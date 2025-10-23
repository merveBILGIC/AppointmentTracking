using AppointmentTracking.Application.DTOs;
using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Catagories.Queries;

public record GetAllCategoriesQuery() : IRequest<Result<IEnumerable<CategoryDto>>>;
