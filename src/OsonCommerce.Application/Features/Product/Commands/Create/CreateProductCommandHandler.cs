using System;
using System.Threading;
using System.Threading.Tasks;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Common.Exceptions;
using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class CreateProductCommandHandler(
    IProductRepository productRepository,
    IRepository<Manufacture> brandRepository,
    IRepository<Category> categoryRepository,
    IValidator<CreateProductCommand> validator,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IRepository<Manufacture> _brandRepository = brandRepository;
    private readonly IRepository<Category> _categoryRepository = categoryRepository;
    private readonly IValidator<CreateProductCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);

        var existingProduct = await _productRepository.GetBySku(request.SKU, cancellationToken);

        if (existingProduct != null)
        {
            throw new ExistingDataException("Product with this SKU already exists!");
        }

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
            SKU = request.SKU,
            ExpiryDate = request.ExpiryDate,
            ManufactureDate = request.ManufactureDate,
            UpdatedAt = DateTime.UtcNow,
            ProductAttributeId =  request.ProductAttributeId
            
        };
        await _productRepository.CreateAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}

