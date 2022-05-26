using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace FridgeProduct.BusinessLayer.MediatR.Pipelines
{
    public class ValidationPipe<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationPipe(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
            {
                return await next();
            }



            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v=>v.Validate(context))
                .SelectMany(result=>result.Errors)
                .Where(f=>f != null)
                .ToList();

            if(failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
