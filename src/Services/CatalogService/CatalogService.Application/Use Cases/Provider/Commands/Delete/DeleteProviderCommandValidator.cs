using FluentValidation;

namespace CatalogService.Application.UseCases
{
    public class DeleteProviderCommandValidator : AbstractValidator<DeleteProviderCommand>
    {
        public DeleteProviderCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}