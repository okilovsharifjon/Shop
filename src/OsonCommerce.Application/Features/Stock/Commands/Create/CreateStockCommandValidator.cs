using FluentValidation;

namespace OsonCommerce.Application.Features;

public class CreateStockCommandValidator : AbstractValidator<CreateStockCommand>
{
    public CreateStockCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty();
        RuleFor(command => command.StockCode).NotEmpty();
        RuleFor(command => command.Location).NotEmpty();
        RuleFor(command => command.Capacity).GreaterThan(0);
        RuleFor(command => command.CurrentLoad).GreaterThanOrEqualTo(0);
        RuleFor(command => command.PhoneNumber).Matches(@"^\+?[1-9]\d{1,14}$"); // Example regex for phone numbers
    }
}
