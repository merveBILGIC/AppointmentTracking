using AppointmentTracking.SharedKernel.Results;
using MediatR;

namespace AppointmentTracking.Application.Features.Catagories.Commands;

public record CreateCategoryCommand(string Name) : IRequest<Result<Guid>>;
