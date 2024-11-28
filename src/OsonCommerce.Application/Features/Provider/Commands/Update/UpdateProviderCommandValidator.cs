using FluentValidation;

namespace OsonCommerce.Application.Features;

public class UpdateProviderCommandValidator : AbstractValidator<UpdateProviderCommand>
{
    public UpdateProviderCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
        RuleFor(command => command.Name).NotEmpty().MaximumLength(100);
        RuleFor(command => command.ContactInfo).NotEmpty().MaximumLength(200);
        RuleFor(command => command.Address).NotEmpty().MaximumLength(300);
        RuleFor(command => command.Email).NotEmpty().EmailAddress();
        RuleFor(command => command.Description).MaximumLength(500);
        RuleFor(command => command.IsActive).NotNull();
    }
}
