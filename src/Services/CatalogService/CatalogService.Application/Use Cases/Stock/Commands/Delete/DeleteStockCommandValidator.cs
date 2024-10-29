using FluentValidation;

namespace CatalogService.Application.UseCases
{
    public class DeleteStockCommandValidator : AbstractValidator<DeleteStockCommand>
    {
        public DeleteStockCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
    