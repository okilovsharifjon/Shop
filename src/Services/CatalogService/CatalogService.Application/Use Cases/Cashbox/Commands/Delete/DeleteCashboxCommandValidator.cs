using FluentValidation;

namespace CatalogService.Application.UseCases
{
    public class DeleteCashboxCommandValidator : AbstractValidator<DeleteCashboxCommand>
    {
        public DeleteCashboxCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
