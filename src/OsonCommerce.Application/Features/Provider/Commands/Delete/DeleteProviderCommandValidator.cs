using FluentValidation;

namespace OsonCommerce.Application.Features
{
    public class DeleteProviderCommandValidator : AbstractValidator<DeleteProviderCommand>
    {
        public DeleteProviderCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}