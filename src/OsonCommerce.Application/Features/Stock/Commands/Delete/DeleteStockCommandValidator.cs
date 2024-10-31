using FluentValidation;

namespace OsonCommerce.Application.Features
{
    public class DeleteStockCommandValidator : AbstractValidator<DeleteStockCommand>
    {
        public DeleteStockCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
    