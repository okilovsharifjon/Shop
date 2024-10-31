using FluentValidation;

namespace OsonCommerce.Application.Features
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Product ID is required.");

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(command => command.CategoryId)
                .NotNull().WithMessage("Category ID is required.");

            RuleFor(command => command.ImageName)
                .NotEmpty().WithMessage("Image name is required.")
                .MaximumLength(255).WithMessage("Image name must not exceed 255 characters.");

            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

            RuleFor(command => command.Weight)
                .GreaterThan(0).WithMessage("Weight must be greater than zero.");
        }
    }
}
