using FluentValidation;

namespace OsonCommerce.Application.Features;

public class LoginEmployeeCommandValidator : AbstractValidator<LoginEmployeeCommand>
{
    public LoginEmployeeCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(100);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
    }
}