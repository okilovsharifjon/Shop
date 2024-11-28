using FluentValidation;

namespace OsonCommerce.Application.Features;

public class CreateProductPriceCommandValidator : AbstractValidator<CreateProductPriceCommand>
{
    public CreateProductPriceCommandValidator()
    {
        
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
