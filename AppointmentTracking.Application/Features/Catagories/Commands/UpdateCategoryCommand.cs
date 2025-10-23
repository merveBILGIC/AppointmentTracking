using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Catagories.Commands;

public record UpdateCategoryCommand(Guid Id, string Name) : IRequest<Result<string>>;
