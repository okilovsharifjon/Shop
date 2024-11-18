using FluentValidation;

namespace OsonCommerce.Application.Features;

public class CreateProductInStockCommandValidator : AbstractValidator<CreateProductInStockCommand>
{
    public CreateProductInStockCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.StockId).NotEmpty();
        RuleFor(x => x.ProductPriceId).NotEmpty();
        RuleFor(x => x.ProviderId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
    }
}