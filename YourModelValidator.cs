using FluentValidation;

namespace FluentValidationActionFilter;

public class YourModelValidator : AbstractValidator<YourModel>
{
    public YourModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required. In YourModelValidator.");
    }
}