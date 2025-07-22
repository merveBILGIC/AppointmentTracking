using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Catagories.Commands;

public record DeleteCategoryCommand(Guid Id) : IRequest<Result<string>>;
