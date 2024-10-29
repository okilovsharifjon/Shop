using FluentValidation;

namespace CatalogService.Application.UseCases
{
    public class AddMoneyToCashboxCommandValidator : AbstractValidator<AddMoneyToCashboxCommand>
    {
        public AddMoneyToCashboxCommandValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.CashboxId).NotEmpty();
        }
    }
}

