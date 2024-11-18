using FluentValidation;

namespace OsonCommerce.Application.Features;

public class RegisterEmployeeCommandValidator : AbstractValidator<RegisterEmployeeCommand>
{
    public RegisterEmployeeCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(100);
        RuleFor(x => x.PhoneNumber).MaximumLength(15);
        RuleFor(x => x.Position).MaximumLength(50);
        RuleFor(x => x.Department).MaximumLength(50);
        RuleFor(x => x.HireDate).NotEmpty();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                                 .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                                 .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                                 .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
    }
}