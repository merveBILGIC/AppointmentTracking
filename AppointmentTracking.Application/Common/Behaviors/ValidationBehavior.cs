
using AppointmentTracking.SharedKernel.Results;
using FluentValidation;
using MediatR;

namespace AppointmentTracking.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                var responseType = typeof(TResponse);
                if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var failResult = Activator.CreateInstance(responseType);
                    responseType.GetProperty("Success")?.SetValue(failResult, false);
                    responseType.GetProperty("Message")?.SetValue(failResult, "Doğrulama hatası oluştu.");
                    responseType.GetProperty("Errors")?.SetValue(failResult, failures.Select(f => f.ErrorMessage).ToList());
                    return (TResponse)failResult!;
                }

                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}

