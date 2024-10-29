using MediatR;

namespace CatalogService.Application.UseCases;

public class DeleteCategoryCommand : IRequest
{
    public Guid Id { get; set; }
}