using FluentValidation;

namespace CatalogService.Application.UseCases
{
    public class UpdateCashboxCommandValidator : AbstractValidator<UpdateCashboxCommand>
    {
        public UpdateCashboxCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(command => command.Key)
                .NotEmpty().WithMessage("Key is required.")
                .Length(5, 50).WithMessage("Key must be between 5 and 50 characters.");

            RuleFor(command => command.IsActive)
                .NotNull().WithMessage("IsActive must be specified.");
        }
    }
}
