using MediatR;

namespace OsonCommerce.Application.Features;

public class CreatePriceTypeCommand : IRequest<Guid>
{
    public string Name { get; set; } // �������� ���� ����, �������� "������ ���������", "������ ���������"
    public string Description { get; set; }
}