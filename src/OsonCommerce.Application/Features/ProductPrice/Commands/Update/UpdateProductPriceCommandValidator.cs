using FluentValidation;

namespace OsonCommerce.Application.Features;

public class UpdateProductPriceCommandValidator : AbstractValidator<UpdateProductPriceCommand>
{
    public UpdateProductPriceCommandValidator()
    {
    RuleFor(command => command.ProductPriceID)
        .NotEmpty().WithMessage("Product Price ID is required.");

    RuleFor(command => command.Price)
        .GreaterThan(0).WithMessage("Price must be greater than zero.");

    RuleFor(command => command.ProductID)
        .NotEmpty().WithMessage("Product ID is required.");

    RuleFor(command => command.PriceTypeID)
        .NotEmpty().WithMessage("Price Type ID is required.");

    RuleFor(command => command.StockID)
        .NotEmpty().WithMessage("Stock ID is required.");
    }
}