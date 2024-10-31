using FluentValidation;

namespace OsonCommerce.Application.Features
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters.");

            RuleFor(command => command.BrandId)
                .NotEmpty().WithMessage("BrandId is required.");

            RuleFor(command => command.CategoryId)
                .NotNull().WithMessage("CategoryId must be specified.");

            RuleFor(command => command.Unit)
                .IsInEnum().WithMessage("Unit must be a valid enum value.");

            RuleFor(command => command.ImageName)
                .MaximumLength(255).WithMessage("ImageName must not exceed 255 characters.");

            RuleFor(command => command.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(command => command.Weight)
                .GreaterThan(0).WithMessage("Weight must be greater than zero.");

            RuleFor(command => command.ManufactureDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("ManufactureDate cannot be in the future.");

            RuleFor(command => command.ExpiryDate)
                .GreaterThan(command => command.ManufactureDate).When(command => command.ExpiryDate.HasValue)
                .WithMessage("ExpiryDate must be after the ManufactureDate.");

            RuleFor(command => command.SKU)
                .NotEmpty().WithMessage("SKU is required.")
                .Length(1, 50).WithMessage("SKU must be between 1 and 50 characters.");
        }
    }
}
