using FluentValidation;

namespace OsonCommerce.Application.Features
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
