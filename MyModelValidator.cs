using FluentValidation;

namespace FluentValidationActionFilter;

public class MyModelValidator : AbstractValidator<MyModel>
{
    public MyModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        // Add more rules as necessary
    }
}