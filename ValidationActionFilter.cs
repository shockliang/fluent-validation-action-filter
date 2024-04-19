using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FluentValidationActionFilter;

public class ValidationActionFilter<T> : IAsyncActionFilter where T : class
{
    private readonly IValidator<T> _validator;

    public ValidationActionFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionArguments.TryGetValue(typeof(T).Name.ToLower(), out var model))
        {
            var result = await _validator.ValidateAsync((T)model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });

                context.Result = new BadRequestObjectResult(errors);
                return;
            }
        }

        await next();
    }
}