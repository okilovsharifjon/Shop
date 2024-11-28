using FluentValidation;

namespace OsonCommerce.Application.Features;

public class WithdrawMoneyFromCashboxCommandValidator : AbstractValidator<WithdrawMoneyFromCashboxCommand>
{
    public WithdrawMoneyFromCashboxCommandValidator()
    {
        RuleFor(command => command.Amount).GreaterThan(0);
        RuleFor(command => command.CashboxId).NotEmpty();
    }
}
