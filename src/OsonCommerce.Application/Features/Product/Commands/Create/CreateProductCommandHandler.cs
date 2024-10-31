using System;
using System.Threading;
using System.Threading.Tasks;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Exceptions;
using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;

namespace OsonCommerce.Application.Features
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Manufacture> _brandRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IValidator<CreateProductCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(
            IRepository<Product> productRepository,
            IRepository<Manufacture> brandRepository,
            IRepository<Category> categoryRepository,
            IValidator<CreateProductCommand> validator,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);

            var brand = await _brandRepository.GetByIdAsync(request.BrandId, cancellationToken);
            if (brand == null)
            {
                throw new NotFoundException("Brand not found");
            }
            if (request.CategoryId != null)
            {
                var category = await _categoryRepository.GetByIdAsync(request.CategoryId.Value, cancellationToken);
                if (category == null)
                {
                    throw new NotFoundException("Category not found");
                }
            }
            var product = new Product
            {
                Name = request.Name,
                ManufactureId = request.BrandId,
                CategoryId = request.CategoryId,
                Unit = request.Unit,
                ImageName = request.ImageName,
                Description = request.Description,
                Weight = request.Weight,
            };
            await _productRepository.CreateAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}

