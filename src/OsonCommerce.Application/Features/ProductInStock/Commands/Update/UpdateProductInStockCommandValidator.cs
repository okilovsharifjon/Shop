using FluentValidation;

namespace OsonCommerce.Application.Features;

public class UpdateProductInStockCommandValidator : AbstractValidator<UpdateProductInStockCommand>
{
    public UpdateProductInStockCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.ProductPriceId).NotEmpty();
        RuleFor(x => x.StockId).NotEmpty();
        RuleFor(x => x.ProviderId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
        RuleFor(x => x.IsAvailable).NotEmpty();
    }
}