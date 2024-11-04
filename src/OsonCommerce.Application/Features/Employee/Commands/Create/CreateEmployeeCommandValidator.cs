using FluentValidation;

namespace OsonCommerce.Application.Features;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(100);
        RuleFor(x => x.PhoneNumber).MaximumLength(15);
        RuleFor(x => x.Position).MaximumLength(50);
        RuleFor(x => x.Department).MaximumLength(50);
        RuleFor(x => x.HireDate).NotEmpty();
    }
}