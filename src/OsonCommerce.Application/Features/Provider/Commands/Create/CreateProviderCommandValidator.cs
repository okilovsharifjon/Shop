using FluentValidation;

namespace OsonCommerce.Application.Features
{
    public class CreateProviderCommandValidator : AbstractValidator<CreateProviderCommand>
    {
        public CreateProviderCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(command => command.ContactInfo).NotEmpty().WithMessage("Contact information is required.");
            RuleFor(command => command.Address).NotEmpty().WithMessage("Address is required.");
            RuleFor(command => command.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
            RuleFor(command => command.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
