using MediatR;

namespace OsonCommerce.Application.Features;

public class UpdateStockCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string StockCode { get; set; }
    public string Location { get; set; }
    public int Capacity { get; set; }
    public int CurrentLoad { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsAvailable { get; set; }
    
}

