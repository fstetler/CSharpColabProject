using FluentValidation;
using FluentValidation.Results;
using Common.Result;
using MediatR;

namespace Common.CommonBehaviors
{
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
            if (!_validators.Any())
            {
                return await next();
            }

            ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);

            ValidationResult[] results = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            List<ValidationFailure> failures = results
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                string errorMessage = string.Join("; ", failures.Select(f => f.ErrorMessage));

                Type responseType = typeof(TResponse);
                if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(Result<>))
                {
                    object? badRequestResult = responseType
                        .GetMethod(nameof(Result<object>.BadRequest))!
                        .Invoke(null, [errorMessage]);

                    return (TResponse)badRequestResult!;
                }

                throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
