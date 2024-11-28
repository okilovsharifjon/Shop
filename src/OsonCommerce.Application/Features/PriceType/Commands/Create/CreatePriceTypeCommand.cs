using MediatR;

namespace OsonCommerce.Application.Features;

public class CreatePriceTypeCommand : IRequest<Guid>
{
    public string Name { get; set; } // Название типа цены, например "Первая категория", "Вторая категория"
    public string Description { get; set; }
}