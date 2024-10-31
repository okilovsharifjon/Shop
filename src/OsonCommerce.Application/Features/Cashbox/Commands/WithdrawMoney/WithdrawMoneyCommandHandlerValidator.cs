using FluentValidation;

namespace OsonCommerce.Application.Features
{
    public class WithdrawMoneyCommandValidator : AbstractValidator<WithdrawMoneyCommand>
    {
        public WithdrawMoneyCommandValidator()
        {
            RuleFor(command => command.Amount).GreaterThan(0);
            RuleFor(command => command.CashboxId).NotEmpty();
        }
    }
}
