using CleanTeeth.Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace CleanTeeth.Application.Utilities;

public class SimpleMediator(IServiceProvider serviceProvider) : IMediator
{
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());
        
        var validator = serviceProvider.GetService(validatorType);

        if (validator is not null)
        {
            var validateMethod = validatorType.GetMethod("ValidateAsync");
            var taskToValidate = (Task)validateMethod!.Invoke(validator, new object[] { request,  CancellationToken.None })!;
            
            await taskToValidate;

            var result = taskToValidate.GetType().GetProperty("Result");
            var validationResult = (ValidationResult)result!.GetValue(taskToValidate)!;

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult);
            }
        }
        
        var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

        var handler = serviceProvider.GetService(handlerType);

        if (handler is null)
        {
            throw new MediatiorException($"Handler was not found for {request.GetType().Name}");
        }
        
        var method = handlerType.GetMethod("Handle");
        return await (Task<TResponse>)method.Invoke(handler, new [] { request });
    }
}