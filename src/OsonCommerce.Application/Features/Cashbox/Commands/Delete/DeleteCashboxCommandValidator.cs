using FluentValidation;

namespace OsonCommerce.Application.Features
{
    public class DeleteCashboxCommandValidator : AbstractValidator<DeleteCashboxCommand>
    {
        public DeleteCashboxCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
