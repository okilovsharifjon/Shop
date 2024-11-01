using FluentValidation;

namespace OsonCommerce.Application.Features;

public class CreateManufactureCommandValidator : AbstractValidator<CreateManufactureCommand>
{
    public CreateManufactureCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(500);
        RuleFor(x => x.LogoName).MaximumLength(255);
        RuleFor(x => x.WebsiteUrl).MaximumLength(255);
        RuleFor(x => x.CountryOfOrigin).MaximumLength(100);
    }
}