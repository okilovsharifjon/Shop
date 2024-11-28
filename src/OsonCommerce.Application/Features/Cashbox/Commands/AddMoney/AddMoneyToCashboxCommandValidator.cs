using FluentValidation;

namespace OsonCommerce.Application.Features;

public class AddMoneyToCashboxCommandValidator : AbstractValidator<AddMoneyToCashboxCommand>
{
    public AddMoneyToCashboxCommandValidator()
    {
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.CashboxId).NotEmpty();
    }
}

