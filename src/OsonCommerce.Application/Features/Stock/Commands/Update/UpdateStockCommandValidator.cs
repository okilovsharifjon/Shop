using FluentValidation;

namespace OsonCommerce.Application.Features;

public class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
{
    public UpdateStockCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
        RuleFor(command => command.Name).NotEmpty().MaximumLength(100);
        RuleFor(command => command.StockCode).NotEmpty().MaximumLength(50);
        RuleFor(command => command.Location).NotEmpty().MaximumLength(200);
        RuleFor(command => command.Capacity).GreaterThan(0);
        RuleFor(command => command.CurrentLoad).GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(command => command.Capacity);
        RuleFor(command => command.PhoneNumber).Matches(@"^\+?[1-9]\d{1,14}$")
            .WithMessage("Phone number must be in E.164 format.");
        RuleFor(command => command.IsAvailable).NotNull();
    }
}
