using FluentValidation;

namespace CatalogService.Application.UseCases
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
